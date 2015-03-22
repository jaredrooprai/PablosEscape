using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MyPlayer : MonoBehaviour {
	
	// different classes
	private Animator animator;
	private Controller controllerScript;
	
	private Vector3 position;		// current position
	private Vector3 newPosition;	// future position
	
	public float speed;			// speed of movement from one vector 3 to another
	public int health;				// Health point value
	
	
	private bool hasWhiteKey ;
	private bool hasRedKey;
	private bool hasBlueKey;
	private bool hasGoldKey;						// determining if player has a key to unlock gate or not
	
	public AudioClip hurt1;
	public AudioClip hurt2;
	public AudioClip hurt3;
	public AudioClip hurt4;
	
	public AudioClip shiny;
	public AudioClip step1;
	public AudioClip step2;
	public AudioClip step3;
	
	public AudioClip mine;
	public AudioClip drink;
	public AudioClip door;
	
	// initializing player attributes
	void Start() {
		
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		PlayerHUD.findGUIObjects ();
		rotatePlayer (); 											// rotating him on start up to face the right way 
		
		
		position = transform.position;			// getting current player position from players transform
		newPosition = transform.position;		// newPosition and position need to be the same at the start in order make sure player can't move in between transitions...
		speed = 4f;								// ... essentially newposition and position work hand in hand
		health = 5;
		
		hasWhiteKey = false;
		hasRedKey = false;
		hasBlueKey = false;
		hasGoldKey = false;
	}
	
	
	
	// Called once every frame
	void Update (){
		#if UNITY_STANDALONE || UNITY_EDITOR 					// if game is running in the editor or on Mac Linux Pc. use keyboard controller
		newPosition = controllerScript.keyboard(position); 		// get players input and new position from keyboard controller
		
		# elif UNITY_ANDROID									// if game is running on android use touchscreen controller
		newPosition = controllerScript.touchScreen(position); 	//get players input and new position from touchscreen controller
		#endif
		movePlayer ();											// attempt to move player to correct grid position
		checkHealth ();											// check if players health changed
		checkKeys ();
	}
	
	
	private void checkKeys(){
		if (hasWhiteKey == true)
			PlayerHUD.toggleWhiteKey(true);
		else 
			PlayerHUD.toggleWhiteKey(false);
		
		if (hasRedKey == true)
			PlayerHUD.toggleRedKey(true);
		else 
			PlayerHUD.toggleRedKey(false);
		
		if (hasBlueKey == true)
			PlayerHUD.toggleBlueKey(true);
		else 
			PlayerHUD.toggleBlueKey(false);
		
		if (hasGoldKey == true)
			PlayerHUD.toggleGoldKey(true);
		else 
			PlayerHUD.toggleGoldKey(false);
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
			SoundManager.instance.randomVoiceFx (mine, shiny);
			hasWhiteKey = true;
			Destroy (other.gameObject);
			
		} else if (other.tag == "RedKey") {
			hasRedKey = true;
			SoundManager.instance.randomVoiceFx (mine, shiny);
			Destroy (other.gameObject);
			
		} else if (other.tag == "BlueKey") {
			SoundManager.instance.randomVoiceFx (mine, shiny);
			hasBlueKey = true;
			Destroy (other.gameObject);
			
		} else if (other.tag == "GoldKey") {
			SoundManager.instance.randomVoiceFx (mine, shiny);
			hasGoldKey = true;
			Destroy (other.gameObject);
			
		} else if (other.tag == "Food") {
			SoundManager.instance.playWalkingFx (drink);
			health += 1;
			Destroy (other.gameObject);
			
		} else if (other.tag == "Trap") {
			SoundManager.instance.randomVoiceFx (hurt1, hurt2, hurt3, hurt4);
			health -= 1;
			
		} else if (other.tag == "Portal") {
			GameManager.instance.finishedLevel ();
			
		} else if (other.tag == "Gate") {
			Destroy (other.gameObject);
		}
		
	}
	
	
	
	
	
	private Vector3 checkCollider(Vector3 start, Vector3 end) {
		rotatePlayer ();																					
		//Debug.DrawLine (start, end, Color.green); 														// shows linecast for debugging purposes
		
		bool wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));			// cast a line and check if its a wall or gate..
		bool whiteGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteGateLayer"));// ..
		bool redGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("redGateLayer"));	// ..
		bool blueGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("blueGateLayer"));	// ..
		bool goldGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldGateLayer"));	// ..
		
		
		if (whiteGateCollision == true && hasWhiteKey == false) { 
			return start;
		} else if (whiteGateCollision == true && hasWhiteKey == true) {
			SoundManager.instance.playWalkingFx(door);
			hasWhiteKey = false;
			animator.SetTrigger("Walk");
			return end;
			
			
		} else if (redGateCollision == true && hasRedKey == false) {
			return start;
		} else if (redGateCollision == true && hasRedKey == true) {
			SoundManager.instance.playWalkingFx(door);
			hasRedKey = false;
			animator.SetTrigger("Walk");
			return end;
			
		} else if (blueGateCollision == true && hasBlueKey == false) {
			return start;
		} else if (blueGateCollision == true && hasBlueKey == true) {
			SoundManager.instance.playWalkingFx(door);
			hasBlueKey = false;
			animator.SetTrigger("Walk");
			return end;
			
		} else if (goldGateCollision == true && hasGoldKey == false) {
			return start;
		} else if (goldGateCollision == true && hasGoldKey == true) {
			SoundManager.instance.playWalkingFx(door);
			hasGoldKey = false;
			animator.SetTrigger("Walk");
			return end;
			
		} else if (wallCollision == true) {
			return start;
		} else {
			SoundManager.instance.randomWalkingFx(step1, step2, step3);
			animator.SetTrigger("Walk");
			return end;
		}
	}
	
	
	
	
}


