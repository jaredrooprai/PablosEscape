using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;

	public Movement moveScript;


	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		moveScript = gameObject.GetComponent<Movement> ();

		moveScript.RotateObject (180);

		moveScript.setVariables (3f, transform.position, animator); // setting speed and setting position

	}

	void Update (){


	#if UNITY_STANDALONE || UNITY_EDITOR
		transform.position = moveScript.moveOnKeys ();
	#else
		transform.position = moveScript.moveOnSwipe();
	#endif

	}

}


