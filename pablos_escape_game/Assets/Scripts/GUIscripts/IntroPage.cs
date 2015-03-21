using UnityEngine;
using System.Collections;

public class IntroPage : MonoBehaviour {
	public AudioClip click;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("Play");
		}	
	}
}
