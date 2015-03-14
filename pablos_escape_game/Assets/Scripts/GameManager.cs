using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there

	public GameObject playerPrefab;
	public GameObject cameraPrefab;

	public MapOne mapOneScript;

	[HideInInspector]public int level;




	// Use this for initialization
	void Awake () {
		mapOneScript = GetComponent<MapOne> ();
		InitGame ();
	}

	void InitGame (){
		level = 1;
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
			spawnPlayer();
			loadLevel ();
		} else if (instance != this) {
			Destroy (gameObject);    
			DontDestroyOnLoad (gameObject);
		}
	}

	public void loadLevel(){
		Destroy (GameObject.Find ("Map"));
		if (level == 1) {
			mapOneScript.setupScene ();
		} else
			gameOver ();
	}

	
	public void spawnPlayer(){
		Instantiate (playerPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);
		Instantiate (cameraPrefab, new Vector3 (0, 0, -10f), Quaternion.identity);

	}
	

	public void playerDied(){
				Destroy (GameObject.Find ("Camera(Clone)"));

		Destroy (GameObject.Find ("Player(Clone)"));


		spawnPlayer ();
		loadLevel ();

	}



	public void gameOver(){
	}







}
