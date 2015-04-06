using UnityEngine;
using System.Collections;

public class TutorialController : MonoBehaviour {

	public AudioClip click;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			StartCoroutine ("loadScene","LevelSelect" );
		}	
	}
	
	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		StartCoroutine ("loadScene","LevelSelect" );
	}
	
	
	public void StartButton(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 1);
		StartCoroutine ("loadScene","Game" );

	}


	IEnumerator loadScene(string sceneName){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (sceneName);
		
	}
}
