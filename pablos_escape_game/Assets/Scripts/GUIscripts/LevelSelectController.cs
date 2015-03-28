using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

	private GameObject level2lock;
	private GameObject level3lock;
	private GameObject level4lock;
	private GameObject level5lock;
	
	public AudioClip click;
	
	
	// Use this for initialization
	void Start () {
		level2lock = GameObject.Find ("level2lock");
		level3lock = GameObject.Find ("level3lock");
		level4lock = GameObject.Find ("level4lock");
		level5lock = GameObject.Find ("level5lock");
	}
	
	// Update is called once per frame
	void Update () {
		disableLocks ();
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}
	}
	
	

	public void disableLocks(){
		if (PlayerPrefs.GetInt ("HighestLevel") >= 2)
			level2lock.SetActive (false);
		else
			level2lock.SetActive (true);

		if (PlayerPrefs.GetInt ("HighestLevel") >= 3)
			level3lock.SetActive (false);
		else
			level3lock.SetActive (true);


		if (PlayerPrefs.GetInt ("HighestLevel") >= 4)
			level4lock.SetActive (false);
		else
			level4lock.SetActive (true);


		if (PlayerPrefs.GetInt ("HighestLevel") >= 5)
			level5lock.SetActive (false);
		else
			level5lock.SetActive (true);

		


		
	}

	

	public void TutorialButton(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 1);
		Application.LoadLevel ("Tutorial");
	}
	
	
	public void level2Button(){
		if (PlayerPrefs.GetInt ("HighestLevel") >= 2) {
			SoundManager.instance.playWalkingFx (click);
			PlayerPrefs.SetInt ("SavedLevel", 2);
			Application.LoadLevel ("Game");
		}
	}
	
	public void level3Button(){
		if (PlayerPrefs.GetInt ("HighestLevel") >= 3) {
			SoundManager.instance.playWalkingFx (click);
			PlayerPrefs.SetInt ("SavedLevel", 3);
			Application.LoadLevel ("Game");
		}
	}
	
	public void level4Button(){
		if (PlayerPrefs.GetInt ("HighestLevel") >= 4) {

			SoundManager.instance.playWalkingFx (click);
			PlayerPrefs.SetInt ("SavedLevel", 4);
			Application.LoadLevel ("Game");
		}
	}
	
	
	public void level5Button(){
		if (PlayerPrefs.GetInt ("HighestLevel") >= 5) {
			SoundManager.instance.playWalkingFx (click);
			PlayerPrefs.SetInt ("SavedLevel", 5);
			Application.LoadLevel ("Game");
		}
		
	}
	
	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}

}
