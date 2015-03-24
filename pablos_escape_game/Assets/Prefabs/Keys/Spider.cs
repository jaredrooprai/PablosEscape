using UnityEngine;
using System.Collections;

public class Spider : MonoBehaviour {

	// Use this for initialization
	public float rpm;
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(0,0,6*rpm*Time.deltaTime);

	}
}
