﻿using UnityEngine;
using System.Collections;

public class AndroidBack : MonoBehaviour {
	
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}
	}
}

