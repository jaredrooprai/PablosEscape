using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	Transform target;	 // target you want to follow, in this case, its the player
	Vector3 Orientation; // offset
	
	
	void Start () 
	{
		// off set of z = = -10, unity needs this to show the Map in a 2d game
		Orientation = new Vector3 (0, 0, -10f);			
		target = GameObject.Find ("Player(Clone)").transform;
	}
	
	void LateUpdate () 
	{
		if (target != null) {
			transform.position = target.position + Orientation;	
		} else {
			Debug.Log("Camera: Can't Find Player");
		}
	}


}