using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	private Vector2 initTouchPos;
	// current location
	private float speed;
	private Vector3 position; 
	private Animator animator;
	
	
	public void setVariables(float s, float rotationDegree, Vector3 currentPosition, Animator currentAnimator) {
		transform.rotation = Quaternion.Euler (0, 0, rotationDegree);
		speed = s;
		position = currentPosition;          // Take the initial position
		animator = currentAnimator;
	}
	
	
	
	public Vector3 touchScreen (){ // this is for the phone
		int fingercount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began){
				initTouchPos = touch.position;
			}
			
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
				fingercount++;
				
				
				if(fingercount ==1 && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended){
					Vector2 touchFacing = (initTouchPos - touch.position).normalized;
					
					if(Vector2.Dot (touchFacing, Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
						position = checkMove (position, (position += Vector3.down), 0);
					
					if(Vector2.Dot (touchFacing, -Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
						position = checkMove (position, (position += Vector3.up), 180);
					
					if(Vector2.Dot (touchFacing, Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
						position = checkMove (position, (position += Vector3.left), 270);
					
					if(Vector2.Dot (touchFacing, -Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
						position = checkMove (position, (position += Vector3.right), 90);
				}
			}
		}
		return Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
	}
	
	
	
	
	public Vector3 keyboard(){  /// this is for the keyboard 
		
		if (Input.GetKey (KeyCode.A) && transform.position == position) 
			position = checkMove (position, (position += Vector3.left), 270);
		
		else if (Input.GetKey (KeyCode.D) && transform.position == position)     
			position = checkMove (position, (position += Vector3.right), 90);
		
		else if (Input.GetKey (KeyCode.W) && transform.position == position)         
			position = checkMove (position, (position += Vector3.up), 180);
		
		else if (Input.GetKey (KeyCode.S) && transform.position == position)        
			position = checkMove (position, (position += Vector3.down), 0);
		
		return Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
	}
	
	
	public Vector3 checkMove(Vector3 start, Vector3 end, float rotationDegree) {
		transform.rotation = Quaternion.Euler (0, 0, rotationDegree);

		// shows linecase for debugging purposes,
		//Debug.DrawLine (start, end, Color.green);
		bool wallCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("WallLayer"));
		bool keyCollision = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("KeyLayer"));

		
		if (keyCollision == true) {
			animator.SetTrigger ("Walk");
			return end;
		} else if (wallCollision == true) {
			return start;
		}else {
			animator.SetTrigger("Walk");
			return end;
		}
	}

}

