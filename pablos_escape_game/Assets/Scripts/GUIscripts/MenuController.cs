using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {

	public AudioClip click;

	void Update(){
		// if android back button is pressed exit game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	public void AboutGameButton(){
		SoundManager.instance.playVoiceFx(click);
		Application.LoadLevel ("AboutGame");
	}
	
	public void PlayButton(){
		SoundManager.instance.playVoiceFx(click);
		Application.LoadLevel ("Play");
	}
}
