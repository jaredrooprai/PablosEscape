using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GooglePlayGames;

public class NextLevelController : MonoBehaviour {
	
	//private GameObject nextLevelButton;
	public AudioClip achievement;
	public AudioClip click;

	public string TutorialAchievementID;
	public string Achievement2ID;
	public string Achievement3ID;
	public string Achievement4ID;
	public string Achievement5ID;
	public string Achievement6ID;

	
	// Use this for initialization
	void Start () {
		SoundManager.instance.playAmbFx(achievement);
		saveHighestLevel ();

		GameObject.Find ("LevelComplete").GetComponent<Text>().text = ("Level " + (PlayerPrefs.GetInt("SavedLevel") - 1) ) + "\nComplete!";

		GameObject.Find ("NextLevel").GetComponentInChildren<Text>().text = ("Level " + (PlayerPrefs.GetInt("SavedLevel")) );


	#if UNITY_EDITOR || UNITY_STANDALONE_WIN
	#elif UNITY_ANDROID		
		checkAchievements();
	#endif
	}
	
	// Update is called once per frame
	void Update () {
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}
	}


	public void checkAchievements(){
		if (PlayerPrefs.GetInt ("SavedLevel") == 2) {
			Social.ReportProgress (TutorialAchievementID, 100.0f, (bool success) => {});
		
		} else if (PlayerPrefs.GetInt ("SavedLevel") == 6) {
			Social.ReportProgress (Achievement2ID, 100.0f, (bool success) => {});

		} else if (PlayerPrefs.GetInt ("SavedLevel") == 7) {
			Social.ReportProgress (Achievement3ID, 100.0f, (bool success) => {});

		} else if (PlayerPrefs.GetInt ("SavedLevel") == 8) {
			Social.ReportProgress (Achievement4ID, 100.0f, (bool success) => {});

		} else if (PlayerPrefs.GetInt ("SavedLevel") == 9) {
			Social.ReportProgress (Achievement5ID, 100.0f, (bool success) => {});

		} else if (PlayerPrefs.GetInt ("SavedLevel") == 10) {
			Social.ReportProgress (Achievement6ID, 100.0f, (bool success) => {});
		}
	}

	public void saveHighestLevel(){
		if (PlayerPrefs.GetInt("HighestLevel") < PlayerPrefs.GetInt("SavedLevel")){
			PlayerPrefs.SetInt("HighestLevel", PlayerPrefs.GetInt("SavedLevel") );
		} 
	}

	public void PlayNextLevelButon(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("Game");
		
	}
	
	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}

}