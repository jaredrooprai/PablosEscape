using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float speed;
	private Animator animator;
	private Controller controllerScript;
	private Vector3 position;
	private Vector3 direction;


	void Start () {
		animator = gameObject.GetComponent<Animator> ();
		controllerScript = gameObject.GetComponent<Controller> ();

		position = transform.position;
		direction = transform.position;

		transform.rotation = Quaternion.Euler (0, 0, 180f);
		speed = 2f;
	}

	void Update (){
	#if UNITY_STANDALONE || UNITY_EDITOR
		direction = controllerScript.keyboard(position);
		movement();
	#else
		direction = controllerScript.touchScreen(position);
		movement();
	#endif
	}



	private void movement(){
		if ( position != (direction) )
			position = checkMove (position, direction);
		
		transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
	}




	public Vector3 checkMove(Vector3 start, Vector3 end) {
		transform.rotation = Quaternion.Euler (0, 0, controllerScript.getRotation());

		//Debug.DrawLine (start, end, Color.green); // shows linecast for debugging purposes
		
		bool wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));
		bool keyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("KeyLayer"));


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





}


