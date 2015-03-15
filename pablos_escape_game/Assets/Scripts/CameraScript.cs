using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	Transform target;
	Vector3 Orientation;
	
	
	void Start () 
	{
		Orientation = new Vector3 (0, 0, -10f);
		target = GameObject.Find ("Player(Clone)").transform;
	}
	
	void LateUpdate () 
	{
		target = GameObject.Find ("Player(Clone)").transform;
		if (target == GameObject.Find ("Player(Clone)").transform){
				transform.position = target.position + Orientation;	
		}else
			Debug.Log("it worked i think");
	}
}