using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using System.Collections;


public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;


	private TutorialMap tutoraialMap;
	private ThreeGateMap threeGateMap;

	private JaredsMap jaredsMap;
	private KevinTsMap kevinTsMap;
	private NathansMap nathansMap;
	private KevinGsMap kevinGsMap;
	private SpiderGroundMap spiderGroundMap;

	private int level;
	private int highestLevel;





	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);

		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
			loadGame ();
			levelManager ();
			spawnPlayer ();

		} else if (instance != this) {
			Destroy (gameObject);    
		}
	}

	

	private void levelManager(){
		if (level == 1) {
			tutoraialMap = GetComponent<TutorialMap> ();
			tutoraialMap.setupScene ();

		} else if (level == 2) {
			tutoraialMap = GetComponent<TutorialMap> ();
			tutoraialMap.setupScene ();

		} else if (level == 3) {
			threeGateMap = GetComponent<ThreeGateMap> ();
			threeGateMap.setupScene ();

		} else if (level == 4) {
			tutoraialMap = GetComponent<TutorialMap> ();
			tutoraialMap.setupScene ();

		} else if (level == 5) {
			tutoraialMap = GetComponent<TutorialMap> ();
			tutoraialMap.setupScene ();

		} else if (level == 6) {
			spiderGroundMap = GetComponent<SpiderGroundMap> ();
			spiderGroundMap.setupScene ();


		} else if (level == 7) {
			jaredsMap = GetComponent<JaredsMap> ();
			jaredsMap.setupScene ();

		} else if (level == 8) {
			nathansMap = GetComponent<NathansMap> ();
			nathansMap.setupScene ();

		} else if (level == 9) {
			kevinTsMap = GetComponent<KevinTsMap> ();
			kevinTsMap.setupScene ();

		} else if (level == 10) {
			kevinGsMap = GetComponent<KevinGsMap> ();
			kevinGsMap.setupScene ();
		}
	}






	public void finishedLevel(){
		level++;
		if (level <= 10) {
			Application.LoadLevel ("NextLevel");
		} else {
			Application.LoadLevel ("FinishedGame");
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
