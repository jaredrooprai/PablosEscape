using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	
	private Vector2 initTouchPos;
	// current location
	private Vector3 position;

	
	public Vector3 touchScreen (Vector3 pos){ // this is for the phone
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}

		position = pos;
		int fingercount = 0;
		foreach (Touch touch in Input.touches) {
			// check if the finger is starting to touch the screen
			if (touch.phase == TouchPhase.Began){
				initTouchPos = touch.position;
			}

			// if the finger has not lifted off the screen and the touch was registered properly
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
				fingercount++;

				// make sure there is only 1 finger, check if finger has moved on the screen or if the finger has swiped and stopped or if the finger is lifted
				if(fingercount == 1 && touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Ended){
					Vector2 touchFacing = (initTouchPos - touch.position).normalized;

					// determine movement vectors and set update variable appropriately 
					if(Vector2.Dot (touchFacing, Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position+=Vector3.down;
					} else if(Vector2.Dot (touchFacing, -Vector2.up) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position+=Vector3.up;
					} else if(Vector2.Dot (touchFacing, Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position+=Vector3.left;
					} else if(Vector2.Dot (touchFacing, -Vector2.right) > 0.8 && Vector2.Distance (initTouchPos, touch.position) > 20 && transform.position == position ){
						position+=Vector3.right;
					}
				}
			}
		}
		//return updates
		return position;
	}





	public Vector3 keyboard(Vector3 pos){  /// this is for the keyboard 
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}

		position = pos;

		if (Input.GetKey (KeyCode.A) && transform.position == position) {
			position+=Vector3.left;
		} else if (Input.GetKey (KeyCode.D) && transform.position == position) {    
			position+=Vector3.right;
		} else if (Input.GetKey (KeyCode.W) && transform.position == position) {        
			position+=Vector3.up;
		} else if (Input.GetKey (KeyCode.S) && transform.position == position) { 
			position+=Vector3.down;
		}
		return (position);
	}




}

