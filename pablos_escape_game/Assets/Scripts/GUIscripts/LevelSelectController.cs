using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

	private GameObject level2;
	private GameObject level3;
	private GameObject level4;
	private GameObject level5;
	
	public AudioClip click;
	
	
	// Use this for initialization
	void Start () {
		level2 = GameObject.Find ("level2");
		level3 = GameObject.Find ("level3");
		level4 = GameObject.Find ("level4");
		level5 = GameObject.Find ("level5");
	}
	
	// Update is called once per frame
	void Update () {
		showCorrectButtons ();
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}
	}
	
	
	
	public void showCorrectButtons(){
		
		if (PlayerPrefs.GetInt ("HighestLevel") > 1)
			level2.SetActive (true);
		else
			level2.SetActive (false);
		
		
		if (PlayerPrefs.GetInt ("HighestLevel") > 2)
			level3.SetActive (true);
		else
			level3.SetActive (false);
		
		
		if (PlayerPrefs.GetInt ("HighestLevel") > 3)
			level4.SetActive (true);
		else
			level4.SetActive (false);
		
		if (PlayerPrefs.GetInt ("HighestLevel") > 4)
			level5.SetActive (true);
		else
			level5.SetActive (false);
		
	}
	

	public void TutorialButton(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 1);
		Application.LoadLevel ("NewGame");
	}
	
	
	public void level2Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 2);
		Application.LoadLevel ("Game");
	}
	
	public void level3Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 3);
		Application.LoadLevel ("Game");
	}
	
	public void level4Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 4);
		Application.LoadLevel ("Game");
	}
	
	
	public void level5Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 5);
		Application.LoadLevel ("Game");
		
	}
	
	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}

}
