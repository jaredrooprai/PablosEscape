using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float speed;
	private Animator animator;
	private Controller controllerScript;
	private Vector3 position;
	private Vector3 direction;

	// called on start up
	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();

		position = transform.position;
		direction = transform.position;

		rotatePlayer (); // rotating him on start up to face the right way 
		speed = 2f;
	}


	// Called every frame
	void Update (){
	#if UNITY_STANDALONE || UNITY_EDITOR
		direction = controllerScript.keyboard(position);
		movePlayer();
	#else
		direction = controllerScript.touchScreen(position);
		movePlayer();
	#endif
	}


	// move the player towards destination
	private void movePlayer(){
		if (position != (direction))
			position = checkCollider (position, direction);

		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
	}

	
	// check for player hitting colliders
	private Vector3 checkCollider(Vector3 start, Vector3 end) {
		rotatePlayer ();
		//Debug.DrawLine (start, end, Color.green); 										// shows linecast for debugging purposes
		
		bool wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));	// cast a line and check if its a wall
		bool keyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("KeyLayer"));	// cast a line and check if its a key

		if (keyCollision == true) {
			return start;
		}

		if (wallCollision == true) {
			return start;
		}else {
			animator.SetTrigger("Walk");
			return end;
		}
	}


	// rotating player to face direction of movement
	private void rotatePlayer(){
		if (((position.x) == (direction.x)) && ((position.y) == (direction.y))) {
			transform.rotation = Quaternion.Euler (0, 0, 180f);
		}else if ((position.x) > (direction.x)) {
			transform.rotation = Quaternion.Euler (0, 0, 270f);
		} else if ((position.x) < (direction.x)) {
			transform.rotation = Quaternion.Euler (0, 0, 90f);
		} else if ((position.y) < (direction.y)) {
			transform.rotation = Quaternion.Euler (0, 0, 180f);
		} else if ((position.y) > (direction.y)) {
			transform.rotation = Quaternion.Euler (0, 0, 0f);
		}
	}
}


