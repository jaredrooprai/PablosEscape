using UnityEngine;
using System.Collections;

public class FinishedGameController : MonoBehaviour {


	public AudioClip laugh;
	public AudioClip click;

	void Start(){
		SoundManager.instance.playVoiceFx(laugh);
	}

	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);

		Application.LoadLevel ("MainMenu");
	}

}
