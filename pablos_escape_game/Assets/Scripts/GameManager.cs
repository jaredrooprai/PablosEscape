﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;

	public Map1 mapOneScript;
	public Map2 mapTwoScript;
	public Map3 mapThreeScript;
	public Map4 mapFourScript;
	public Map5 mapFiveScript;

	[HideInInspector]public int level;

	void Save ()
	{
		PlayerPrefs.SetInt("SavedLevel", level);
	}


	void Load ()
	{
		if (PlayerPrefs.GetInt ("SavedLevel") == 0) {
			level = 1;
		} else {
			level = PlayerPrefs.GetInt ("SavedLevel");
		}
	}



	// Use this for initialization
	void Awake () {
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
			InitGame ();
		} else if (instance != this) {
			Destroy (gameObject);    
			DontDestroyOnLoad (gameObject);
		}
	}



	void InitGame (){
		mapOneScript = GetComponent<Map1> ();
		mapTwoScript = GetComponent<Map2> ();
		mapThreeScript = GetComponent<Map3> ();
		mapFourScript = GetComponent<Map4> ();
		mapFiveScript = GetComponent<Map5> ();

		
		Load ();
		levelManager ();
		spawnPlayer();
	}

	

	
	public void levelManager(){
		Destroy (GameObject.Find ("Map"));
		if (level == 1) {
			mapOneScript.setupScene ();
		} else if (level == 2) {
			mapTwoScript.setupScene ();
		} else if (level == 3) {
			mapThreeScript.setupScene ();
		} else if (level == 4) {
			mapFourScript.setupScene ();
		} else if (level == 5) {
			mapFiveScript.setupScene ();
		}else {
			level =1;
			Application.LoadLevel ("FinishedGame");
		}

		Save ();

	}




	public void finishedLevel(){
		Destroy (GameObject.Find ("Player(Clone)"));
		level++;
		Save ();
		Application.LoadLevel ("NextLevel");
		levelManager ();
		spawnPlayer ();
	}




	public void spawnPlayer(){
		Instantiate (playerPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);

	}




	public void playerDied(){
		Application.LoadLevel ("PlayerDead");

		Destroy (GameObject.Find ("Player(Clone)"));
		levelManager ();
		spawnPlayer ();
	}





	public void gameOver(){
		Application.LoadLevel ("MainMenu");
	}







}
