using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	Transform target;		//Target for player vector3
	Vector3 Orientation;	//Offset for the -10 on z axis or the character would not be visible 
							//due to the nature of the Unity system
	
	
	void Start () 		
	{
		Orientation = new Vector3 (0, 0, -10f);
		target = GameObject.Find ("Player(Clone)").transform;
	}
	
	void LateUpdate () 
	{
	
		//Method to set the camera on the location of the player at all times based on the players
		//position and orientation.
		if (target != null) {
			transform.position = target.position + Orientation;	
		} else {
			//Debug.Log("Camera: Can't Find Player");
		}
	}


}