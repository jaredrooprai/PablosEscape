using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	// current location
	private Vector3 position; 
	private float speed;
	private Vector2 touchOrigin = -Vector2.one;
	
	public void setVariables(float s, Vector3 currentPosition) {
		speed = s;
		position = currentPosition;          // Take the initial position
	}
	

	
	public Vector3 moveOnSwipe (){ // this is for the phone
		if (Input.touchCount == 0) {
			Touch myTouch = Input.touches[0];
			if (myTouch.phase == TouchPhase.Began) {
				touchOrigin = myTouch.position;
			}
			else if (myTouch.phase == TouchPhase.Ended && touchOrigin.x >=0) {
				Vector2 touchEnd = myTouch.position;
				float x = touchEnd.x - touchOrigin.x;
				float y = touchEnd.y - touchOrigin.y;
				touchOrigin.x = -1;
				if (Mathf.Abs(x) > Mathf.Abs(y)) {
					if (x > 0)
						position = checkMove(position, (position += Vector3.right));
					else
						position = checkMove(position, (position += Vector3.left));
				}
				else {
					if (y > 0)
						position = checkMove(position, (position += Vector3.up));
					else 
						position = checkMove(position, (position += Vector3.down));
				}
			}
		}
		return Vector3.MoveTowards(transform.position, position, Time.deltaTime * speed);
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
		bool collide = Physics2D.Linecast (start, end, 1 << LayerMask.NameToLayer ("BlockingLayer"));
		if (collide == true)
			return start;
		else 
			return end;
	}

}

