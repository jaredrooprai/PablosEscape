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

		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevelButton(){
		SoundManager.instance.playWalkingFx(click);

		Application.LoadLevel ("Game");
	}




}
