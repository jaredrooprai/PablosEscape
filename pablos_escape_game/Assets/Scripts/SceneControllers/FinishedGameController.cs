using UnityEngine;
using System.Collections;

public class FinishedGameController : MonoBehaviour {

	public string Achievement7ID;

	public AudioClip achievement;
	public AudioClip click;

	void Start(){
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
#elif UNITY_ANDROID
		Social.ReportProgress ( Achievement7ID, 100.0f, (bool success) =>{});
#endif
		SoundManager.instance.playAmbFx(achievement);
	}

	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);

		StartCoroutine ("loadScene","MainMenu");
	}

	IEnumerator loadScene(string sceneName){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (sceneName);
		
	}

}
