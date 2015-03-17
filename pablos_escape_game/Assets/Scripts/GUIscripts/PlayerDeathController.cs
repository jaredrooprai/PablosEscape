﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDeathController : MonoBehaviour {
	
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}	
		GameObject.Find ("Restart Level").GetComponentInChildren<Text>().text = "Restart Level " + PlayerPrefs.GetInt("SavedLevel");

	}
	
	
	public void MenuButton(){
		Application.LoadLevel ("MainMenu");
	}

	public void RestartLevelButton(){
		Application.LoadLevel ("Game");

	}
}
