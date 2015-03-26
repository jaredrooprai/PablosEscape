using UnityEngine;
using System.Collections;

public class FinishedGameController : MonoBehaviour {

	public string Achievement5ID;

	public AudioClip achievement;
	public AudioClip click;

	void Start(){
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
#elif UNITY_ANDROID
		Social.ReportProgress ( Achievement5ID, 100.0f, (bool success) =>{});
#endif
		SoundManager.instance.playAmbFx(achievement);
	}

	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);

		Application.LoadLevel ("MainMenu");
	}

}
