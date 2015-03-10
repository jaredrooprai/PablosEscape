using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour 
{
	Transform target;
	
	Vector3 Orientation;
	
	
	void Start () 
	{
		Orientation = new Vector3 (0, 0, -10f);
		target = GameObject.Find ("Player").transform;
	}
	
	void LateUpdate () 
	{
		transform.position = target.position + Orientation;	
	}
}