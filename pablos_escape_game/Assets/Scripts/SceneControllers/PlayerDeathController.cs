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
			StartCoroutine ("loadScene","MainMenu");
		}	

	}
	
	
	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);
		StartCoroutine ("loadScene","MainMenu");
	}

	public void RestartLevelButton(){
		SoundManager.instance.playWalkingFx(click);
		StartCoroutine ("loadScene","Game");
	}


	IEnumerator loadScene(string sceneName){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (sceneName);
		
	}
}
