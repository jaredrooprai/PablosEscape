using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;
	private Controller controllerScript;
	private PlayerHUD HUDScript;

	private Vector3 position;		// current position
	private Vector3 newPosition;	// future position

	private float speed;			// speed of movement, will be multiplied by time.delta time

	// booleans for colliding with objects
	private bool wallCollision;		
	private bool whiteKeyCollision, whiteGateCollision,	hasWhiteKey;
	private bool tealKeyCollision, tealGateCollision,	hasTealKey;
	private bool goldKeyCollision, goldGateCollision,	hasGoldKey;




// initializing player 
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		HUDScript = gameObject.GetComponent<PlayerHUD> ();

		initHUD ();

		position = transform.position;
		newPosition = transform.position;

		rotatePlayer (); // rotating him on start up to face the right way 
		speed = 2f;

		hasWhiteKey = false;
		hasTealKey = false;
		hasGoldKey = false;
	}


	// Called every frame**********************************************************
	void Update (){
	// if game is running in the editor or on Mac Linux Pc. use keyboard controller
	#if UNITY_STANDALONE || UNITY_EDITOR 
		newPosition = controllerScript.keyboard(position); 		// get input from the keyboard fucntion in controller
	// if game is running on android use touchscreen controller
	# elif UNITY_ANDROID
		newPosition = controllerScript.touchScreen(position); 	// get input from the touchscreen fucntion in controller
	#endif
		movePlayer();// attempt to move player to correct grid position
	}

	private void initHUD (){ 		//initializeing Heads up display
		HUDScript.toggleHeart_1(true);
		HUDScript.toggleHeart_2(true);
		HUDScript.toggleHeart_3(true);
		HUDScript.toggleHeart_4(true);
		HUDScript.toggleHeart_5(true);
		HUDScript.toggleKey_1(false);
		HUDScript.toggleKey_2(false);
		HUDScript.toggleKey_3(false);
	}

	//object interaction methods**************************************
	private void foundWhiteKey(){
		hasWhiteKey = true;
		playerWalkAnim ();
		Destroy (GameObject.Find ("whiteKey(Clone)"));
		HUDScript.toggleKey_1(true);
	}
	private void foundTealKey(){	
		hasTealKey = true;
		playerWalkAnim ();
		Destroy (GameObject.Find ("tealKey(Clone)"));
		HUDScript.toggleKey_2(true);
	}
	private void foundGoldKey(){	
		hasGoldKey = true;
		playerWalkAnim ();
		Destroy (GameObject.Find ("goldKey(Clone)"));
		HUDScript.toggleKey_3(true);
	}


	private void unlockWhiteGate(){
		HUDScript.toggleKey_1 (false);
		playerWalkAnim ();
		Destroy (GameObject.Find ("whiteGate(Clone)"));	
	}
	private void unlockTealGate(){
		HUDScript.toggleKey_2 (false);
		playerWalkAnim ();
		Destroy (GameObject.Find ("tealGate(Clone)"));
		
	}
	private void unlockGoldGate(){
		HUDScript.toggleKey_3 (false);
		playerWalkAnim ();
		Destroy (GameObject.Find ("goldGate(Clone)"));
	}



	// move the player towards destination****************************
	private void movePlayer(){
		if (position != (newPosition))
			position = checkCollider (position, newPosition);

		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
	}



	// check for player hitting colliders*****************************
	private Vector3 checkCollider(Vector3 start, Vector3 end) {
		rotatePlayer ();
		//Debug.DrawLine (start, end, Color.green); // shows linecast for debugging purposes
		
		wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));	// cast a line and check if its a wall
		whiteKeyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteKeyLayer"));	
		tealKeyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("tealKeyLayer"));	
		goldKeyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldKeyLayer"));

		whiteGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteGateLayer"));	// cast a line and check if its a key
		tealGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("tealGateLayer"));	// cast a line and check if its a key
		goldGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldGateLayer"));	// cast a line and check if its a key

		if (whiteGateCollision == true && hasWhiteKey == false) { 
			return start;
		} else if (whiteGateCollision == true && hasWhiteKey == true) {
			unlockWhiteGate();
			return end;

		} else if (tealGateCollision == true && hasTealKey == false) {
			return start;
		}else if (tealGateCollision == true && hasTealKey == true) {
			unlockTealGate();
			return end;

		} else if (goldGateCollision == true && hasGoldKey == false) {
			return start;
		} else if (goldGateCollision == true && hasGoldKey == true) {
			unlockGoldGate();
			return end;

		} else if (tealGateCollision == true && hasTealKey == false) {
			return start;
		}else if (tealGateCollision == true && hasTealKey == true) {
			unlockTealGate();
			return end;
		
		} else if (wallCollision == true) {
			return start;
		} else if (whiteKeyCollision == true && hasWhiteKey == false) {
			foundWhiteKey ();
			return end;
		} else if (tealKeyCollision == true && hasTealKey == false) {
			foundTealKey ();
			return end;
		} else if (goldKeyCollision == true && hasGoldKey == false) {
			foundGoldKey ();
			return end;
		}else {
			playerWalkAnim();
			return end;
		}
	}

                         
	                           
	// rotating player to face direction of movement******************
	private void rotatePlayer(){
		if (((position.x) == (newPosition.x)) && ((position.y) == (newPosition.y))) {
			transform.rotation = Quaternion.Euler (0, 0, 180f);
		}else if ((position.x) > (newPosition.x)) {
			transform.rotation = Quaternion.Euler (0, 0, 270f);
		} else if ((position.x) < (newPosition.x)) {
			transform.rotation = Quaternion.Euler (0, 0, 90f);
		} else if ((position.y) < (newPosition.y)) {
			transform.rotation = Quaternion.Euler (0, 0, 180f);
		} else if ((position.y) > (newPosition.y)) {
			transform.rotation = Quaternion.Euler (0, 0, 0f);
		}
	}
	

	private void playerWalkAnim(){// walking animation ***************
		animator.SetTrigger("Walk");
	}


	
}


