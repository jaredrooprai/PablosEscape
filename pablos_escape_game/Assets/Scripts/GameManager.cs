using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using System.Collections;


public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;

	public Map1 mapOneScript;
	public Map2 mapTwoScript;
	public Map3 mapThreeScript;
	public Map4 mapFourScript;
	public Map5 mapFiveScript;
	
	[HideInInspector]public int level;
	[HideInInspector]public int highestLevel;





	// Use this for initialization
	void Awake () {
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
			loadGame ();
			levelManager ();
			spawnPlayer ();

		} else if (instance != this) {
			Destroy (gameObject);    
		}
		DontDestroyOnLoad (gameObject);

	}

	

	private void levelManager(){
		if (level == 1) {
			mapOneScript = GetComponent<Map1> ();
			mapOneScript.setupScene ();
		} else if (level == 2) {
			mapTwoScript = GetComponent<Map2> ();
			mapTwoScript.setupScene ();
		} else if (level == 3) {
			mapThreeScript = GetComponent<Map3> ();
			mapThreeScript.setupScene ();
		} else if (level == 4) {
			mapFourScript = GetComponent<Map4> ();
			mapFourScript.setupScene ();
		} else if (level == 5) {
			mapFiveScript = GetComponent<Map5> ();
			mapFiveScript.setupScene ();
		}
	}




	public void finishedLevel(){
		level++;
		if (level < 6) {
			Application.LoadLevel ("NextLevel");
		} else {
			Application.LoadLevel ("FinishedGame");
			level = 1;
		}
		saveGame ();
	}


	
	private void spawnPlayer(){
		Instantiate (playerPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);
	}


	public void playerDied(){
		Application.LoadLevel ("PlayerDead");
	}


	public void gameOver(){

		Application.LoadLevel ("MainMenu");
	}

	private void saveGame ()
	{
		PlayerPrefs.SetInt("SavedLevel", level);
	}
	
	
	private void loadGame ()
	{
		if (PlayerPrefs.GetInt ("SavedLevel") == 0)
			level = 1;
		else
			level = PlayerPrefs.GetInt ("SavedLevel");
	}


	
	





}
