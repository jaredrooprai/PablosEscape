using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;

	public MapOne mapOneScript;
	public MapTwo mapTwoScript;
	public MapThree mapThreeScript;
	public MapFour mapFourScript;
	public MapFive mapFiveScript;


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
		mapOneScript = GetComponent<MapOne> ();
		mapTwoScript = GetComponent<MapTwo> ();
		mapThreeScript = GetComponent<MapThree> ();
		mapFourScript = GetComponent<MapFour> ();
		mapFiveScript = GetComponent<MapFive> ();
		Load ();
		levelManager ();
		spawnPlayer();
	}

	

	
	public void levelManager(){
		Save ();
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
		} else {
			Application.LoadLevel ("MainMenu");
		}

	}




	public void finishedLevel(){
		Destroy (GameObject.Find ("Player(Clone)"));
		level++;
		levelManager ();
		spawnPlayer ();
	}




	public void spawnPlayer(){
		Instantiate (playerPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);

	}




	public void playerDied(){
		Destroy (GameObject.Find ("Player(Clone)"));
		levelManager ();
		spawnPlayer ();
	}





	public void gameOver(){
		Application.LoadLevel ("MainMenu");
	}







}
