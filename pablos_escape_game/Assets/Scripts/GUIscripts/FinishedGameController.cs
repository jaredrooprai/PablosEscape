using UnityEngine;
using System.Collections;

public class FinishedGameController : MonoBehaviour {

	public string Achievement5ID;

	public AudioClip laugh;
	public AudioClip click;

	void Start(){
		Social.ReportProgress ( Achievement5ID, 100.0f, (bool success) =>{});
		SoundManager.instance.playVoiceFx(laugh);
	}

	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);

		Application.LoadLevel ("MainMenu");
	}

}
