using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {



	private bool WindowOpen;
	public AudioClip click;



	// Use this for initialization
	void Start () {
		WindowOpen = false;
		PlayerHUD.toggleOptionsPanel (false);
	}



	public void OptionsButton(){
		SoundManager.instance.playWalkingFx(click);

		if (WindowOpen == true) {
			PlayerHUD.toggleOptionsPanel (false);
			WindowOpen = false;
		} else {
			PlayerHUD.toggleOptionsPanel (true);
			WindowOpen = true;
		}
	}

	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);

		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevelButton(){
		SoundManager.instance.playWalkingFx(click);

		Application.LoadLevel ("Game");
	}




}
