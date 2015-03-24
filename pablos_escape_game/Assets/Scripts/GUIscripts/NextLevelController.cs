using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using System.Collections;
using GooglePlayGames;

public class NextLevelController : MonoBehaviour {
	
	//private GameObject nextLevelButton;
	public AudioClip laugh;
	public AudioClip click;

	public string Achievement1ID;
	public string Achievement2ID;
	public string Achievement3ID;
	public string Achievement4ID;

	
	// Use this for initialization
	void Start () {
		SoundManager.instance.playVoiceFx(laugh);
		saveHighestLevel ();
		ButtonText ();

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


	public void ButtonText(){
		if (PlayerPrefs.GetInt ("SavedLevel") == 2) 
			GameObject.Find ("NextLevel").GetComponentInChildren<Text>().text = "Clausterphobia";

	}
	public void checkAchievements(){
		if (PlayerPrefs.GetInt ("SavedLevel") == 2) {
			Social.ReportProgress ( Achievement1ID, 100.0f, (bool success) =>{});
		
		} else if (PlayerPrefs.GetInt("SavedLevel") == 3) {
			Social.ReportProgress ( Achievement2ID, 100.0f, (bool success) =>{});

		} else if (PlayerPrefs.GetInt("SavedLevel") == 4) {
			Social.ReportProgress ( Achievement3ID, 100.0f, (bool success) =>{});

		} else if (PlayerPrefs.GetInt("SavedLevel") == 5) {
			Social.ReportProgress ( Achievement4ID, 100.0f, (bool success) =>{});

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