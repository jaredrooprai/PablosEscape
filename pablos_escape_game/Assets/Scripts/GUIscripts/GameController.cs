using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {



	private bool WindowOpen;



	// Use this for initialization
	void Start () {
		WindowOpen = false;
		PlayerHUD.toggleOptionsPanel (false);
	}



	public void OptionsButton(){
		if (WindowOpen == true) {
			PlayerHUD.toggleOptionsPanel (false);
			WindowOpen = false;
		} else {
			PlayerHUD.toggleOptionsPanel (true);
			WindowOpen = true;
		}
	}

	public void MenuButton(){
		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevelButton(){
		Application.LoadLevel ("Game");
	}




}
