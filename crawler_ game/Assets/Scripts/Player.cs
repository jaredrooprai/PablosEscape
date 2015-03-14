using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

	private Animator animator;
	private Controller controllerScript;
	private PlayerHUD HUDScript;

	private Vector3 position;		// current position
	private Vector3 newPosition;	// future position

	private float speed;			// speed of movement, will be multiplied by time.delta time
	private int health;
	// booleans for colliding with objects
	private bool wallCollision;		
	private bool whiteGateCollision, hasWhiteKey;
	private bool tealGateCollision, hasTealKey;
	private bool goldGateCollision,	hasGoldKey;




// initializing player 
	void Start () {

		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		HUDScript = gameObject.GetComponent<PlayerHUD> ();

		initHUD ();		// initialize health and key gui
		rotatePlayer (); // rotating him on start up to face the right way 

	
		position = transform.position;
		newPosition = transform.position;
		speed = 4f;
		health = 5;

		hasWhiteKey = false;
		hasTealKey = false;
		hasGoldKey = false;
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
		checkHealth ();
	}

	

	// move the player towards destination****************************
	private void movePlayer(){
		if (position != (newPosition)) {
			position = checkCollider (position, newPosition);
		}
		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
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
	

	
	// check for player hitting colliders*****************************
	private Vector3 checkCollider(Vector3 start, Vector3 end) {
		rotatePlayer ();
		//Debug.DrawLine (start, end, Color.green); // shows linecast for debugging purposes
		
		wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));	// cast a line and check if its a wall
		whiteGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteGateLayer"));	// cast a line and check if its a key
		tealGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("tealGateLayer"));	// cast a line and check if its a key
		goldGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldGateLayer"));	// cast a line and check if its a key


		if (whiteGateCollision == true && hasWhiteKey == false) { 
			return start;
		} else if (whiteGateCollision == true && hasWhiteKey == true) {
			unlockWhiteGate ();
			return end;

		} else if (tealGateCollision == true && hasTealKey == false) {
			return start;
		} else if (tealGateCollision == true && hasTealKey == true) {
			unlockTealGate ();
			return end;

		} else if (goldGateCollision == true && hasGoldKey == false) {
			return start;
		} else if (goldGateCollision == true && hasGoldKey == true) {
			unlockGoldGate ();
			return end;

		} else if (wallCollision == true) {
			return start;
		} else {
			animator.SetTrigger("Walk");
			return end;
		}
	}



	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "WhiteKey") {
			foundWhiteKey ();
			Destroy (other.gameObject);
		} else if (other.tag == "TealKey") {
			foundTealKey ();
			Destroy (other.gameObject);

		} else if (other.tag == "GoldKey" ) {
			foundGoldKey ();
			Destroy (other.gameObject);

		} else if (other.tag == "Milk") {
			increaseHealth ();
			Destroy (other.gameObject);
		} else if (other.tag == "Trap") {
			decreaseHealth(); 
		}

	}



	private void checkHealth(){
		if (health > 5) 
			health = 5;
		
		if (health >= 1){HUDScript.toggleHeart_1(true);}
		else{ HUDScript.toggleHeart_1(false); Application.LoadLevel(Application.loadedLevel);}
		
		if (health >= 2){HUDScript.toggleHeart_2(true);}
		else{ HUDScript.toggleHeart_2(false); }
		
		if (health >= 3){HUDScript.toggleHeart_3(true);}
		else{ HUDScript.toggleHeart_3(false); }
		
		if (health >= 4){HUDScript.toggleHeart_4(true);}
		else{ HUDScript.toggleHeart_4(false); }
		
		if (health >= 5){HUDScript.toggleHeart_5(true);}
		else{ HUDScript.toggleHeart_5(false); }
	}


	private void increaseHealth(){
		health += 1;
	}


	private void decreaseHealth(){
		health -= 1;
	}



	//object interaction methods**************************************
	private void foundWhiteKey(){
		hasWhiteKey = true;
		HUDScript.toggleKey_1(true);
	}
	private void foundTealKey(){	
		hasTealKey = true;
		HUDScript.toggleKey_2(true);
	}
	private void foundGoldKey(){	
		hasGoldKey = true;
		HUDScript.toggleKey_3(true);
	}



	
	private void unlockWhiteGate(){
		HUDScript.toggleKey_1 (false);
		animator.SetTrigger("Walk");
		Destroy (GameObject.Find ("whiteGate(Clone)"));	
	}
	private void unlockTealGate(){
		HUDScript.toggleKey_2 (false);
		animator.SetTrigger("Walk");
		Destroy (GameObject.Find ("tealGate(Clone)"));
		
	}
	private void unlockGoldGate(){
		HUDScript.toggleKey_3 (false);
		animator.SetTrigger("Walk");
		Destroy (GameObject.Find ("goldGate(Clone)"));
	}
	
	

                         



	
}


