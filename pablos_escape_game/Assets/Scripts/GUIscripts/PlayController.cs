using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayController : MonoBehaviour {
	
	private GameObject room2;
	private GameObject room3;
	private GameObject room4;
	private GameObject room5;

	public AudioClip click;

	
	// Use this for initialization
	void Start () {
		room2 = GameObject.Find ("room2");
		room3 = GameObject.Find ("room3");
		room4 = GameObject.Find ("room4");
		room5 = GameObject.Find ("room5");
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
			room2.SetActive (true);
		else
			room2.SetActive (false);


		if (PlayerPrefs.GetInt ("HighestLevel") > 2)
			room3.SetActive (true);
		else
			room3.SetActive (false);


		if (PlayerPrefs.GetInt ("HighestLevel") > 3)
			room4.SetActive (true);
		else
			room4.SetActive (false);

		if (PlayerPrefs.GetInt ("HighestLevel") > 4)
			room5.SetActive (true);
		else
			room5.SetActive (false);

	}


	//PlayerPrefs.GetInt("HighestLevel")

	void Room1Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 1);
		Application.LoadLevel ("NewGame");
	}
	

	void Room2Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 2);
		Application.LoadLevel ("Game");
	}

	void Room3Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 3);
		Application.LoadLevel ("Game");
	}

	void Room4Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 4);
		Application.LoadLevel ("Game");
	}


	void Room5Button(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 5);
		Application.LoadLevel ("Game");

	}

	void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}
	

	

}