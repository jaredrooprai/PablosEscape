using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null; 
	public MapOne boardscript;



	// Use this for initialization
	void Awake () {
		boardscript = GetComponent<MapOne> ();
		InitGame ();
	}

	void InitGame (){
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);    
		
		DontDestroyOnLoad(gameObject);
		boardscript.setupScene();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
