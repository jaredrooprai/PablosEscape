using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	private Vector2 initTouchPos;
	// current location
	private Vector3 position;




	public Vector3 touchScreen (Vector3 pos){ // this is for the phone
		position = pos;
		int fingercount = 0;
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began){
				initTouchPos = touch.position;
			}
			
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
				fingercount++;

				if(fingercount ==1 && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended){
					Vector2 touchFacing = (initTouchPos - touch.position).normalized;
					
					if(Vector2.Dot (touchFacing, Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position = position += Vector3.down;
					} else if(Vector2.Dot (touchFacing, -Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position = position += Vector3.up;
					} else if(Vector2.Dot (touchFacing, Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position = position += Vector3.left;
					} else if(Vector2.Dot (touchFacing, -Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position = position += Vector3.right;
					}
				}
			}
		}
		return position;
	}




	public Vector3 keyboard(Vector3 pos){  /// this is for the keyboard 
		position = pos;

		if (Input.GetKey (KeyCode.A) && transform.position == position) {
			position = position += Vector3.left;
		} else if (Input.GetKey (KeyCode.D) && transform.position == position) {    
			position = position += Vector3.right;
		} else if (Input.GetKey (KeyCode.W) && transform.position == position) {        
			position = position += Vector3.up;
		} else if (Input.GetKey (KeyCode.S) && transform.position == position) { 
			position = position += Vector3.down;
		}
		return position;
	}




}

