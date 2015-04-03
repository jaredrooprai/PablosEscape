using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MyPlayer : MonoBehaviour {
	
	// different classes
	private Animator animator;
	private Controller controllerScript;
	
	private Vector3 position;				// current position
	private Vector3 newPosition;			// future position
	
	public float speed;						// speed of movement from one vector 3 to another
	public int health;						// Health point value
	
	
	private bool hasWhiteKey ;				//check to see if the white key is flagged
	private bool hasRedKey;					//check to see if the red key is flagged
	private bool hasBlueKey;				//check to see if the blue key has been flagged
	private bool hasGoldKey;				// determining if player has a key to unlock gate or not

											//These audio clips are randomly chosen when the player is on the trapTile
	public AudioClip hurt1;				
	public AudioClip hurt2;
	public AudioClip hurt3;
	public AudioClip hurt4;

	public AudioClip shiny;					//This is the audio clip is randomly generated with mine for keys
	public AudioClip mine;					//This is the audio clip is randomly generated with shiny for keys

	public AudioClip step1;					//One of the clips that is randomly selected when the player is moving
	public AudioClip step2;					
	public AudioClip step3;

	public AudioClip drink;					//Audio clip when the drink is picked up
	public AudioClip gate1, gate2;			//One of two of these audio clips are chosen when the gate is unlocked

	public AudioClip alert;					//*******
	
	// initializing player attributes
	void Start() {
		
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		PlayerHUD.findGUIObjects ();
		rotatePlayer (); 											// rotating him on start up to face the right way 
		
		
		position = transform.position;			// getting current player position from players transform
		newPosition = transform.position;		// newPosition and position need to be the same at the start in order make sure player can't move in between transitions...
		speed = 4f;								// ... essentially newposition and position work hand in hand
		health = 5;								// Sets the health for the player

		//the hasKey method is default set to false
		hasWhiteKey = false;					
		hasRedKey = false;
		hasBlueKey = false;
		hasGoldKey = false;
	}
	
	
	
	// Called once every frame
	void Update (){
#if UNITY_STANDALONE || UNITY_EDITOR 							// if game is running in the editor or on Mac Linux Pc. use keyboard controller
		newPosition = controllerScript.keyboard(position); 		// get players input and new position from keyboard controller
		
# elif UNITY_ANDROID											// if game is running on android use touchscreen controller
		newPosition = controllerScript.touchScreen(position); 	//get players input and new position from touchscreen controller
#endif
		movePlayer ();											// attempt to move player to correct grid position
		checkHealth ();											// check if players health changed
		checkKeys ();
	}
	
	
	private void checkKeys(){									//Check keys method checks to see if any of the hasKeys is flagged 
																//If flagged then set toggle HUD to to true
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
			position = checkCollider (position, newPosition);	// check players future positino for colliders
			PlayerHUD.toggleOptionsPanel (false);

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
		if (other.tag == "WhiteKey" ) {
			if (hasWhiteKey == false){
				SoundManager.instance.randomVoiceFx (mine, shiny);
				hasWhiteKey = true;
				Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);
			}
			
		} else if (other.tag == "RedKey") {
			if (hasRedKey == false) {
				hasRedKey = true;
				SoundManager.instance.randomVoiceFx (mine, shiny);
				Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);
			}
			
		} else if (other.tag == "BlueKey") {
			if (hasBlueKey == false){
			SoundManager.instance.randomVoiceFx (mine, shiny);
			hasBlueKey = true;
			Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);

			}
			
		} else if (other.tag == "GoldKey") {
			if (hasGoldKey == false){
				SoundManager.instance.randomVoiceFx (mine, shiny);
				hasGoldKey = true;
				Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);
			}

			//When the player has obtained the "Food" then there will be a +1 on the health
		} else if (other.tag == "Food") {
			SoundManager.instance.playGatefx (drink);
			health += 1;
			Destroy (other.gameObject);
			
		} else if (other.tag == "Trap") {
			SoundManager.instance.randomVoiceFx (hurt1, hurt2, hurt3, hurt4);
			health -= 1;

			//When the player has obtained the "Portal" then it will send the user to the finished level scene
		} else if (other.tag == "Portal") {
			GameManager.instance.finishedLevel ();

			//This will generate one of the audio sound clips
		} else if (other.tag == "Gate") {
			SoundManager.instance.playGatefx(gate1, gate2);

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
		
		//Checking whether the key has been obtained by the player 
		//If so, when the player collides with the gate of the color key the player has then he will be able to *unlock* it
		//and walk through afterwards
		if (whiteGateCollision == true && hasWhiteKey == false) { 
			return start;
		} else if (whiteGateCollision == true && hasWhiteKey == true) {
			hasWhiteKey = false;
			animator.SetTrigger("Walk");
			return end;
			
			
		} else if (redGateCollision == true && hasRedKey == false) {
			return start;
		} else if (redGateCollision == true && hasRedKey == true) {
			hasRedKey = false;
			animator.SetTrigger("Walk");
			return end;
			
		} else if (blueGateCollision == true && hasBlueKey == false) {
			return start;
		} else if (blueGateCollision == true && hasBlueKey == true) {
			hasBlueKey = false;
			animator.SetTrigger("Walk");
			return end;
			
		} else if (goldGateCollision == true && hasGoldKey == false) {
			return start;
		} else if (goldGateCollision == true && hasGoldKey == true) {
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


