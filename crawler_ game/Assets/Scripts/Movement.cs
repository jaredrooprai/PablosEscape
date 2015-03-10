using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	// current location
	private Vector3 position; 
	private float speed;
//<<<<<<< HEAD
	private Vector2 touchOrigin = -Vector2.one;
//=======
	private Animator animator;
//>>>>>>> 8e370b3b430142fe8e4f178d10385e2e2530c2cb
	
	public void setVariables(float s, Vector3 currentPosition) {
		animator = GetComponent<Animator>();
		speed = s;
		position = currentPosition;          // Take the initial position
	}
	

	
	public Vector3 moveOnSwipe (){ // this is for the phone
		if (Input.touchCount > 0) {
			Touch touch = Input.touches[0]; //The first touch is stored in touch
			
			switch(touch.phase)
			{
			case(TouchPhase.Began):
				touchOrigin = touch.position;
				break;
				
			case(TouchPhase.Ended):
				float xSwipeDistance = (new Vector3(touch.position.x,0,0) - new Vector3(touchOrigin.x,0,0)).magnitude;
				float ySwipeDistance = (new Vector3(0, touch.position.y,0) - new Vector3(0, touchOrigin.y,0)).magnitude;
				
				if ((xSwipeDistance - ySwipeDistance) > 0)
				{

					float horizontalDisplacement = touch.position.x- touchOrigin.x;
					if (horizontalDisplacement > 0) //Move Right
					{
						position = checkMove(position, (position += Vector3.right));
					}
					
					else
						position = checkMove(position,(position += Vector3.left)); //else move right
				}
				
				else
				{
					float verticalDisplacement = touch.position.x- touchOrigin.x;
					if (verticalDisplacement > 0)
					{
						position = checkMove(position, (position += Vector3.up));	//move up
					}
					
					else
						position = checkMove(position, (position += Vector3.down));	
				}
				break;
			}
		}
		return Vector2.MoveTowards(transform.position, position, Time.deltaTime * speed);
	}
	

	
		
		
		
	public Vector3 moveOnKeys(){  /// this is for the keyboard 
			
		if(Input.GetKey(KeyCode.A) && transform.position == position) 
			position = checkMove(position,(position += Vector3.left));
				
		else if(Input.GetKey(KeyCode.D) && transform.position == position)     
			position = checkMove(position, (position += Vector3.right));		
		
		else if(Input.GetKey(KeyCode.W) && transform.position == position)         
			position = checkMove(position, (position += Vector3.up));		
		
		else if(Input.GetKey(KeyCode.S) && transform.position == position)        
			position = checkMove(position, (position += Vector3.down));	

		return Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);

	}
	
	Vector3 checkMove(Vector3 start, Vector3 end) {
		// shows linecase for debugging purposes,
		//Debug.DrawLine (start, end, Color.green);
		bool collide = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("BlockingLayer"));
		if (collide == true)
			return start;
		else {
			animator.SetTrigger("bonesWalking");
			return end;
		}
	}

}

