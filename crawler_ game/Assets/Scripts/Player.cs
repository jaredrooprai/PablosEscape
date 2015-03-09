using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	public Movement moveScript;


	void Start () {
		moveScript = gameObject.GetComponent<Movement> ();
		moveScript.setVariables (3f, transform.position); // setting speed and setting position
	}

	void Update (){
	#if UNITY_STANDALONE || UNITY_EDITOR
		transform.position = moveScript.moveOnKeys ();
	#else
		transform.position = moveScript.moveOnSwipe();
	#endif

	}

}


