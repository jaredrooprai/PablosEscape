using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector2 initTouchPos;
	// current location
	private float speed;
	private Vector3 position; 
	private Animator animator;


	public void setVariables(float s, Vector3 currentPosition, Animator currentAnimator) {
		speed = s;
		position = currentPosition;          // Take the initial position
		animator = currentAnimator;
	}
	

	
	public Vector3 moveOnSwipe (){ // this is for the phone
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
							setDown	();
						
						if(Vector2.Dot (touchFacing, -Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
							setUp ();

						if(Vector2.Dot (touchFacing, Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
							setLeft();	
						
						if(Vector2.Dot (touchFacing, -Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position )
							setRight();						
					}
				}
			}
			return Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
		}

	

		
	public Vector3 moveOnKeys(){  /// this is for the keyboard 
			
		if (Input.GetKey (KeyCode.A) && transform.position == position) 
			setLeft();
		
		else if (Input.GetKey (KeyCode.D) && transform.position == position)     
			setRight();

		else if (Input.GetKey (KeyCode.W) && transform.position == position)         
			setUp();

		else if (Input.GetKey (KeyCode.S) && transform.position == position)        
			setDown();


		return Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);

	}



	public void RotateObject (float zcoord){
		if (transform.rotation.z != zcoord) {
			transform.rotation = Quaternion.Euler (0, 0, zcoord);
		}
	}

	
	Vector3 checkMove(Vector3 start, Vector3 end) {
		// shows linecase for debugging purposes,
		//Debug.DrawLine (start, end, Color.green);
		bool collide = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("BlockingLayer"));
		if (collide == true)
			return start;
		else {
			animator.SetTrigger("Walk");
			return end;
		}
	}

	private void setDown(){
		position = checkMove (position, (position += Vector3.down));
		RotateObject(0);
	}
	
	private void setRight(){
		position = checkMove (position, (position += Vector3.right));
		RotateObject(90);
	}
	
	private void setUp(){
		position = checkMove (position, (position += Vector3.up));
		RotateObject(180);
	}
	
	private void setLeft(){
		position = checkMove (position, (position += Vector3.left));
		RotateObject(270);
	}


}

