using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;
using GooglePlayGames;
using System.Collections;


public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;				//Setting the player


	private TutorialMap tutorialMap;			//Setting up the tutorial map
	private EZPZMap easyMap;					//Setting up the easy map

	private ThreeGateMap threeGateMap;			//Setting up the threeGateMap
	private FourStoryMap fourStoryMap;			//Setting up the fourStoryMap
	private TheFiveFXMap fiveFxMap;				//Setting up the map five

	
	private JaredsMap jaredsMap;				//Setting up the jaredsMap
	private KevinTsMap kevinTsMap;				//Setting up the kevinTsMap
	private NathansMap nathansMap;				//Setting up the nathansMap
	private KevinGsMap kevinGsMap;				//Setting up the kevinGsMap
	private SpiderGroundMap spiderGroundMap;	//Setting up the spiderGroundMap

	private int level;							//Setting up the level attribute
	private int highestLevel;					//Setting up the highestLevel





	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad (gameObject);

		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
			loadGame ();				//Method to load the game
			levelManager ();			//Method to set up starting map	
			spawnPlayer ();				//Method to spawn location of player on the map

		} else if (instance != this) {
			Destroy (gameObject);    	//Destroy game Object to check there is only one instance
		}
	}

	

	private void levelManager(){
		//Set level to 1 and set up according to tutorialMap
		if (level == 1) {			
			tutorialMap = GetComponent<TutorialMap> ();
			tutorialMap.setupScene ();	
		
		//Set level to 2 and set up according to easyMap
		} else if (level == 2) {
			easyMap = GetComponent<EZPZMap> ();
			easyMap.setupScene ();
		
		//Set level to 3 and set up according to threeGateMap
		} else if (level == 3) {
			threeGateMap = GetComponent<ThreeGateMap> ();
			threeGateMap.setupScene ();

		//Set level to 4 and set up according to fourStoryMap
		} else if (level == 4) {
			fourStoryMap = GetComponent<FourStoryMap> ();
			fourStoryMap.setupScene ();

		//Set level to 5 and set up according to fiveFxMap
		} else if (level == 5) {
			fiveFxMap = GetComponent<TheFiveFXMap> ();
			fiveFxMap.setupScene ();

		//Set level to 6 and set up according to spiderGroundMap
		} else if (level == 6) {
			spiderGroundMap = GetComponent<SpiderGroundMap> ();
			spiderGroundMap.setupScene ();

		//Set level to 7 and set up according to jaredsMap
		} else if (level == 7) {
			jaredsMap = GetComponent<JaredsMap> ();
			jaredsMap.setupScene ();

		//Set level to 8 and set up according to nathansMap
		} else if (level == 8) {
			nathansMap = GetComponent<NathansMap> ();
			nathansMap.setupScene ();

		//Set level to 9 and set up according to kevinTsMap
		} else if (level == 9) {
			kevinTsMap = GetComponent<KevinTsMap> ();
			kevinTsMap.setupScene ();
		
		//Set level to 10 and set up according to kevinGsMap
		} else if (level == 10) {
			kevinGsMap = GetComponent<KevinGsMap> ();
			kevinGsMap.setupScene ();
		}
	}





	//Check to see if the player has completed levels.
	public void finishedLevel(){
		level++;
		if (level <= 10) {
			Application.LoadLevel ("NextLevel");
		} else {
			Application.LoadLevel ("FinishedGame");
		}
		saveGame ();	//Calls saveGame method when the player has completed a level.
	}


	//Method used to spawn player on map
	private void spawnPlayer(){
		Instantiate (playerPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);
	}

	//Method if the player dies then the PlayerDead scene is loaded
	public void playerDied(){
		Application.LoadLevel ("PlayerDead");
	}

	//Method if the game has finished the MainMenu scene is loaded
	public void gameOver(){
		Application.LoadLevel ("MainMenu");
	}

	//Method once the player has completed a level
	private void saveGame ()
	{
		PlayerPrefs.SetInt("SavedLevel", level);	//Saves the integer of the level 

	}	

	//Method to load the game.
	private void loadGame ()
	{
		if (PlayerPrefs.GetInt ("SavedLevel") == 0)		//Checks to sees if the player has completed a level and the integer has been stored
			level = 1;
		else
			level = PlayerPrefs.GetInt ("SavedLevel");	
	}


	
	





}
