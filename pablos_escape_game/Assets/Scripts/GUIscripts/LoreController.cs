using UnityEngine;
using System.Collections;

public class LoreController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}	
	}
	
	public void BackButton(){
		Application.LoadLevel ("MainMenu");
	}
}
