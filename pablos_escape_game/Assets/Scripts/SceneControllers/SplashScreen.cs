using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class SplashScreen : MonoBehaviour {
	
	public AudioClip click;
	
	void Awake(){
		StartCoroutine ("SplashLogo");
	}

	IEnumerator SplashLogo(){
		yield return new WaitForSeconds (2f);
		StartCoroutine ("loadScene");


	}

	IEnumerator loadScene(){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("MainMenu");
	}


	
	void Update(){
		// if android back button is pressed exit game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}



