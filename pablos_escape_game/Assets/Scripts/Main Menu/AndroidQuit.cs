using UnityEngine;
using System.Collections;

public class AndroidQuit: MonoBehaviour {
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
}

