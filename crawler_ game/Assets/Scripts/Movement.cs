using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	// current location
	private Vector3 position; 
	private float speed;
	
	public void setVariables(float s, Vector3 currentPosition) {
		speed = s;
		position = currentPosition;          // Take the initial position
	}
	

	
	public void moveOnSwipe (){ // this is for the phone

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

