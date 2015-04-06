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
		StartCoroutine ("loadScene", "MainMenu");
	}

	IEnumerator loadScene(string sceneName){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (sceneName);
		
	}
}
