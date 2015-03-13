using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Animator animator;
	private Controller controllerScript;
	private PlayerHUD HUDScript;

	private Vector3 position;
	private Vector3 newPosition;

	private float speed;

	private bool wallCollision;
	private bool whiteKeyCollision;
	private bool tealKeyCollision;
	private bool goldKeyCollision;


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
		playerWalkAnim ();
		Destroy (GameObject.Find ("whiteKey(Clone)"));
		HUDScript.toggleKey_1(true);
	
	}
	private void foundTealKey(){						
		playerWalkAnim ();
		Destroy (GameObject.Find ("tealKey(Clone)"));
		HUDScript.toggleKey_2(true);
		
	}
	private void foundGoldKey(){						
		playerWalkAnim ();
		Destroy (GameObject.Find ("goldKey(Clone)"));
		HUDScript.toggleKey_3(true);
		
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
		whiteKeyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteKeyLayer"));	// cast a line and check if its a key
		tealKeyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("tealKeyLayer"));	// cast a line and check if its a key
		goldKeyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldKeyLayer"));	// cast a line and check if its a key

		if (wallCollision == true) {
			return start;
		} else if (whiteKeyCollision == true) {
			foundWhiteKey ();
			return end;
		}else if (tealKeyCollision == true) {
			foundTealKey ();
			return end;
		}else if (goldKeyCollision == true) {
			foundGoldKey ();
			return end;
		}
		else {
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


