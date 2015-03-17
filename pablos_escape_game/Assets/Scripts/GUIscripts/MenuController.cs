using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	void Update(){
		// if android back button is pressed exit game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	public void AboutGameButton(){
		Application.LoadLevel ("AboutGame");
	}
	
	public void PlayButton(){
		Application.LoadLevel ("Play");
	}
	
	public void LoreButton(){
		Application.LoadLevel ("Lore");
	}
}
