using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDeathController : MonoBehaviour {
	public AudioClip hurt1;
	public AudioClip click;



	
	void Start(){
		SoundManager.instance.playVoiceFx(hurt1);
		GameObject.Find ("Restart Level").GetComponentInChildren<Text>().text = "Restart Level " + PlayerPrefs.GetInt("SavedLevel");

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}	

	}
	
	
	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevelButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("Game");

	}
}
