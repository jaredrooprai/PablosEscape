using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public Movement moveScript;

	void Start () {
		moveScript = gameObject.GetComponent<Movement> ();
		moveScript.initMovement (); // setting speed and setting position
	}

	void Update (){
	#if UNITY_STANDALONE || UNITY_EDITOR
		moveScript.moveOnKeys ();
	#else
		moveScript.moveOnSwipe();
	#endif
	}

}


