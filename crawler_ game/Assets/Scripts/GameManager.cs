using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;	// used in init game explanation is there
	public MapOne mapscript;



	// Use this for initialization
	void Awake () {
		mapscript = GetComponent<MapOne> ();
		InitGame ();
	}

	void InitGame (){
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null){
			instance = this;
			mapscript.setupScene ();	
	}
		else if (instance != this)
			Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
