using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there
	public MapOne mapScript;
	public Player playerScript;




	// Use this for initialization
	void Awake () {
		mapScript = GetComponent<MapOne> ();
		InitGame ();
	}

	void InitGame (){
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
			mapScript.setupScene ();
		} else if (instance != this) {
			Destroy (gameObject);    
			DontDestroyOnLoad (gameObject);
		}
	}




}
