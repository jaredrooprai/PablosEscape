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
			PlayerHUD.toggleOptionsPanel (true);
			WindowOpen = false;
		} else {
			PlayerHUD.toggleOptionsPanel (false);
			WindowOpen = true;
		}
	}






}
