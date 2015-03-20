using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : MonoBehaviour {

	// different classes
	private Animator animator;
	private Controller controllerScript;

	private Vector3 position;		// current position
	private Vector3 newPosition;	// future position

	public float speed;			// speed of movement from one vector 3 to another
	public int health;				// Health point value


	private bool hasWhiteKey ;
	private bool hasTealKey;
	private bool hasGoldKey;						// determining if player has a key to unlock gate or not


// initializing player attributes
	void Start() {

		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		initHUD ();													// initialize health and key gui
		rotatePlayer (); 											// rotating him on start up to face the right way 

	
		position = transform.position;			// getting current player position from players transform
		newPosition = transform.position;		// newPosition and position need to be the same at the start in order make sure player can't move in between transitions...
		speed = 4f;								// ... essentially newposition and position work hand in hand
		health = 5;

		hasWhiteKey = false;
		hasTealKey = false;
		hasGoldKey = false;
	}



	// Called once every frame
	void Update (){
	#if UNITY_STANDALONE || UNITY_EDITOR 					// if game is running in the editor or on Mac Linux Pc. use keyboard controller
		newPosition = controllerScript.keyboard(position); 		// get players input and new position from keyboard controller

	# elif UNITY_ANDROID									// if game is running on android use touchscreen controller
		newPosition = controllerScript.touchScreen(position); 	//get players input and new position from touchscreen controller
	#endif

		movePlayer();											// attempt to move player to correct grid position
		checkHealth ();											// check if players health changed

	}

	// initializing players heads up display
	private void initHUD (){ 
		PlayerHUD.setVariables ();
		PlayerHUD.toggleHeart_1(false);
		PlayerHUD.toggleHeart_2(false);
		PlayerHUD.toggleHeart_3(false);
		PlayerHUD.toggleHeart_4(false);
		PlayerHUD.toggleHeart_5(false);
		PlayerHUD.toggleKey_1(false);
		PlayerHUD.toggleKey_2(false);
		PlayerHUD.toggleKey_3(false);
	}



	//  updates health HUD in playerHUD class and makes sure that the health stays in bound. ( 0 <= health <= 5
	private void checkHealth(){
		if (health > 5) 
			health = 5;

		if (health >= 1){PlayerHUD.toggleHeart_1(true);}
		else{ PlayerHUD.toggleHeart_1(false); }
		
		if (health >= 2){PlayerHUD.toggleHeart_2(true);}
		else{ PlayerHUD.toggleHeart_2(false); }
		
		if (health >= 3){PlayerHUD.toggleHeart_3(true);}
		else{ PlayerHUD.toggleHeart_3(false); }
		
		if (health >= 4){PlayerHUD.toggleHeart_4(true);}
		else{ PlayerHUD.toggleHeart_4(false); }
		
		if (health >= 5){PlayerHUD.toggleHeart_5(true);}
		else{ PlayerHUD.toggleHeart_5(false); }

		if (health < 1) {
			//PlayerHUD.activateAll ();
			GameManager.instance.playerDied ();
		}
			
	}





	// move the player towards destination
	private void movePlayer(){
		if (position != (newPosition)) {																// if player is not standing still
			position = checkCollider (position, newPosition);											// check players future positino for colliders
		}
		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);	// move the player to his new or old position
	}





	// rotating player to face direction of movement
	private void rotatePlayer(){
		if (((position.x) == (newPosition.x)) && ((position.y) == (newPosition.y))) {		// first if statement is really just there to make the player face upwards... 
			transform.rotation = Quaternion.Euler (0, 0, 180f);								//... when the game starts
		}else if ((position.x) > (newPosition.x)) {
			transform.rotation = Quaternion.Euler (0, 0, 270f);								// rotating on z coord in terms of degrees
		} else if ((position.x) < (newPosition.x)) {
			transform.rotation = Quaternion.Euler (0, 0, 90f);
		} else if ((position.y) < (newPosition.y)) {
			transform.rotation = Quaternion.Euler (0, 0, 180f);
		} else if ((position.y) > (newPosition.y)) {
			transform.rotation = Quaternion.Euler (0, 0, 0f);
		}
	}





	// detecting for gates and walls is done with linecasting, but interactable items are done with triggers on the box colliders and their tags
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "WhiteKey") {
			hasWhiteKey = true;
			PlayerHUD.toggleKey_1 (true);
			Destroy (other.gameObject);
		} else if (other.tag == "TealKey") {
			hasTealKey = true;
			PlayerHUD.toggleKey_2 (true);
			PlayerHUD.toggleHeart_4 (true); //****************************************
			Destroy (other.gameObject);

		} else if (other.tag == "GoldKey") {
			hasGoldKey = true;
			PlayerHUD.toggleKey_3 (true);
			Destroy (other.gameObject);

		} else if (other.tag == "Food") {
			health += 1;
			Destroy (other.gameObject);
		} else if (other.tag == "Trap") {
			health -= 1;
		} else if (other.tag == "Portal") {
			//PlayerHUD.activateAll ();
			GameManager.instance.finishedLevel ();
		} else if (other.tag == "Button") {
			Destroy(other);
		}

	}





	private Vector3 checkCollider(Vector3 start, Vector3 end) {
		rotatePlayer ();																					
		//Debug.DrawLine (start, end, Color.green); 														// shows linecast for debugging purposes
		
		bool  wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));			// cast a line and check if its a wall or gate..
		bool whiteGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteGateLayer"));// ..
		bool tealGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("tealGateLayer"));	// ..
		bool goldGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldGateLayer"));	// ..
		
		
		if (whiteGateCollision == true && hasWhiteKey == false) { 
			return start;
		} else if (whiteGateCollision == true && hasWhiteKey == true) {
			PlayerHUD.toggleKey_1 (false);
			animator.SetTrigger("Walk");
			Destroy (GameObject.Find ("whiteGate(Clone)"));
			return end;


		} else if (tealGateCollision == true && hasTealKey == false) {
			return start;
		} else if (tealGateCollision == true && hasTealKey == true) {
			PlayerHUD.toggleKey_2 (false);
			animator.SetTrigger("Walk");
			Destroy (GameObject.Find ("tealGate(Clone)"));
			return end;


		} else if (goldGateCollision == true && hasGoldKey == false) {
			return start;
		} else if (goldGateCollision == true && hasGoldKey == true) {
			PlayerHUD.toggleKey_3 (false);
			animator.SetTrigger("Walk");

			Destroy (GameObject.Find ("goldGate(Clone)"));
			return end;
			
		} else if (wallCollision == true) {
			return start;
		} else {
			animator.SetTrigger("Walk");
			return end;
		}
	}



	
}


