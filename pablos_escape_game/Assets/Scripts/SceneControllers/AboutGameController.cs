using UnityEngine;
using System.Collections;

public class AboutGameController : MonoBehaviour {
	public AudioClip click;


	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}	
	}

	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}
}
