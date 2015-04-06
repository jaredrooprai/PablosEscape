using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {



	public AudioClip click;



	// Use this for initialization
	void Start () {
		PlayerHUD.toggleOptionsPanel (false);
	}



	public void OptionsButton(){
		SoundManager.instance.playWalkingFx(click);
		PlayerHUD.toggleOptionsPanel ();
	}


	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);

		StartCoroutine ("loadScene", "MainMenu");
	}

	public void RestartLevelButton(){
		SoundManager.instance.playWalkingFx(click);

		StartCoroutine ("loadScene", "Game");
	}


	IEnumerator loadScene(string sceneName){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (sceneName);
		
	}



}
