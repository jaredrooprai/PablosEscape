using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MyPlayer : MonoBehaviour {
	
	// different classes
	private Animator animator;
	private Controller controllerScript;

	private Vector3 position;		// current position
	private Vector3 newPosition;	// future position
	
	public float speed;				// speed of movement from one vector 3 to another
	

	// audio for getting hurt and stepping
	public AudioClip hurt1, hurt2, hurt3, hurt4;
	public AudioClip step1, step2, step3;

	// voice audio for picking up keys
	public AudioClip shiny, mine;

	// drink sound
	public AudioClip drink;

	// sounds the gate makes
	public AudioClip gate1, gate2;

	// sound for trying to get same key twice
	public AudioClip alert;
	
	// initializing player attributes
	void Start() {
		
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();
		PlayerHUD.findGUIObjects ();
		rotatePlayer (); 											// rotating him on start up to face the right way 
		
		
		position = transform.position;			// getting current player position from players transform
		newPosition = transform.position;		// newPosition and position need to be the same at the start in order make sure player can't move in between transitions...
		speed = 4f;								// ... essentially newposition and position work hand in hand
		
        //initializing health
        PlayerHealth.health = 5;    

        // initializing keys
		Inventory.whiteKey = false;
        Inventory.redKey = false;
        Inventory.blueKey = false;
        Inventory.goldKey = false;
	}
	
	
	
	// Called once every frame
	void Update (){
#if UNITY_STANDALONE || UNITY_EDITOR 							// if game is running in the editor or on Mac Linux Pc. use keyboard controller
		newPosition = controllerScript.keyboard(position); 		// get players input and new position from keyboard controller
		
# elif UNITY_ANDROID											// if game is running on android use touchscreen controller
		newPosition = controllerScript.touchScreen(position); 	//get players input and new position from touchscreen controller
#endif
		movePlayer ();											// attempt to move player to correct grid position
		Inventory.manageKeys ();

		PlayerHealth.manageHealth ();											// check if players health changed
		if (PlayerHealth.IsPlayerDead () == true)
			GameManager.instance.playerDied ();
	}
	

	
	// move the player towards destination
	private void movePlayer(){
		// if player is not standing still
		if (position != (newPosition)) {				
			// check collision of current position to future position
			position = checkCollider (position, newPosition);											
			PlayerHUD.toggleOptionsPanel (false);
		}
		// move the player to his new or old position
		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);	
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
	

	
	// Each Gameobject has a trigger, and triggers go off when the player steps on them, each gameobject also has a tag
	// and we can get the tag by other.tag to check what it is,
	//

	// This method is handling what happens when player triggers a game object
	// Only interactable gameobjects are here, walls and boxs don't have triggers becuase player never steps on them
	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "WhiteKey" ) {
			if (Inventory.whiteKey == false){
				SoundManager.instance.randomVoiceFx (mine, shiny);
                Inventory.whiteKey = true;
				Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);
			}
			
		} else if (other.tag == "RedKey") {
            if (Inventory.redKey == false) {
                Inventory.redKey = true;
				SoundManager.instance.randomVoiceFx (mine, shiny);
				Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);
			}
			
		} else if (other.tag == "BlueKey") {
            if (Inventory.blueKey == false){
			SoundManager.instance.randomVoiceFx (mine, shiny);
            Inventory.blueKey = true;
			Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);

			}
			
		} else if (other.tag == "GoldKey") {
            if (Inventory.goldKey == false) {
				SoundManager.instance.randomVoiceFx (mine, shiny);
                Inventory.goldKey = true;
				Destroy (other.gameObject);
			} else {
				SoundManager.instance.playAlertFx(alert);
			}
			
		} else if (other.tag == "Food") {
			SoundManager.instance.playGatefx (drink);
			PlayerHealth.incHealth();
			Destroy (other.gameObject);
			
		} else if (other.tag == "Trap") {
			SoundManager.instance.randomVoiceFx (hurt1, hurt2, hurt3, hurt4);
			PlayerHealth.decHealth();

		} else if (other.tag == "Portal") {
			GameManager.instance.finishedLevel ();
			
		} else if (other.tag == "Gate") {
			SoundManager.instance.playGatefx(gate1, gate2);

			Destroy (other.gameObject);
		}
		
	}
	
	
	
	

	// This is check if there is something infront of the player that the player should not be able to walk into
	// this method does not handle deleting gates, the OnTriggerEnter2D() method will take care of this
	private Vector3 checkCollider(Vector3 start, Vector3 end) {
		rotatePlayer ();																					
		//Debug.DrawLine (start, end, Color.green); 														// shows linecast for debugging purposes
		
		bool wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));			// cast a line and check if its a wall or gate..
		bool whiteGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("whiteGateLayer"));// ..
		bool redGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("redGateLayer"));	// ..
		bool blueGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("blueGateLayer"));	// ..
		bool goldGateCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("goldGateLayer"));	// ..


        if (whiteGateCollision == true && Inventory.whiteKey == false)
        { 
			return start;
        }
        else if (whiteGateCollision == true && Inventory.whiteKey == true)
        {
            Inventory.whiteKey = false;
			animator.SetTrigger("Walk");
			return end;


        }
        else if (redGateCollision == true && Inventory.redKey == false)
        {
			return start;
        }
        else if (redGateCollision == true && Inventory.redKey == true)
        {
            Inventory.redKey = false;
			animator.SetTrigger("Walk");
			return end;

        }
        else if (blueGateCollision == true && Inventory.blueKey == false)
        {
			return start;
        }
        else if (blueGateCollision == true && Inventory.blueKey == true)
        {
            Inventory.blueKey = false;
			animator.SetTrigger("Walk");
			return end;

        }
        else if (goldGateCollision == true && Inventory.goldKey == false)
        {
			return start;
        }
        else if (goldGateCollision == true && Inventory.goldKey == true)
        {
            Inventory.goldKey = false;
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


