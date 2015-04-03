using UnityEngine;
using System.Collections;

public class SpinPrefab : MonoBehaviour {

	// rotations per min
	public float rpm;
	//  public to set in prefab inspector



	// Update is called once per frame
	void Update () {
		//rotate on z axis
		transform.Rotate(0,0,6*rpm*Time.deltaTime);
		
	}
}
