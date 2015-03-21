using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayController : MonoBehaviour {
	
	private GameObject resume_button;
	public AudioClip click;

	
	// Use this for initialization
	void Start () {
		resume_button = GameObject.Find ("Continue");

		if (PlayerPrefs.GetInt ("SavedLevel") == 1 || PlayerPrefs.GetInt ("SavedLevel") ==0) {
			resume_button.SetActive (false);
		}
		else{
			resume_button.SetActive(true);
			GameObject.Find ("Continue").GetComponentInChildren<Text>().text = "Level " + PlayerPrefs.GetInt("SavedLevel");
			
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}
				
	}
	
	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}
	
	public void NewGameButton(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 1);
		Application.LoadLevel ("Game");
		
	}
	
	public void ContinueButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("Game");
	}
}