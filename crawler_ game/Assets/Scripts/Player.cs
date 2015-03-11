using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;

	public Controller controllerScript;


	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		
		controllerScript.setVariables (2f,180f, transform.position, animator); // setting speed and setting position

	}

	void Update (){


	#if UNITY_STANDALONE || UNITY_EDITOR
		transform.position = controllerScript.keyboard ();
	#else
		transform.position = controllerScript.touchScreen();
	#endif

	}

}


