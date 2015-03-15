using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;

	public MapOne mapOneScript;
	public MapTwo mapTwoScript;
	public MapThree mapThreeScript;
	public MapFour mapFourScript;
	public MapFive mapFiveScript;
	private GameObject levelindic;





	[HideInInspector]public int level;




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
		levelindic = GameObject.Find ("Image");
		mapOneScript = GetComponent<MapOne> ();
		mapTwoScript = GetComponent<MapTwo> ();
		mapThreeScript = GetComponent<MapThree> ();
		mapFourScript = GetComponent<MapFour> ();
		mapFiveScript = GetComponent<MapFive> ();
		levelindic.SetActive (false);

		
		level = 1;
		loadLevel ();
		spawnPlayer();
	}


	public void loadLevel(){
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

	/*
	public void delayit(){
		float x = Time.realtimeSinceStartup + 4f;

		while (x > Time.realtimeSinceStartup) {
			print (Time.realtimeSinceStartup);
		}
		levelindic.SetActive (false);
	}
	*/

	public void finishedLevel(){
		Destroy (GameObject.Find ("Player(Clone)"));
		level++;
		loadLevel ();
		spawnPlayer ();
	}


	public void spawnPlayer(){
		Instantiate (playerPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);

	}


	public void playerDied(){
		Destroy (GameObject.Find ("Player(Clone)"));
		loadLevel ();
		spawnPlayer ();
	}





	public void gameOver(){
		Application.LoadLevel ("MainMenu");
	}







}
