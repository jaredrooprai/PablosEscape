using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour 
{
	public GameObject gameManager;
	public AudioClip click;

	void Awake ()
	{
		if (GameManager.instance == null)
			Instantiate(gameManager);
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}
	}

}
