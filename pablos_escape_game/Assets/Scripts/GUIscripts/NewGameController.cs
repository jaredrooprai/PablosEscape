using UnityEngine;
using System.Collections;

public class NewGameController : MonoBehaviour {
	
	public AudioClip click;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("LevelSelect");
		}	
	}
	
	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("LevelSelect");
	}
	
	
	public void StartButton(){
		SoundManager.instance.playWalkingFx(click);
		PlayerPrefs.SetInt("SavedLevel", 1);
		Application.LoadLevel ("Game");
		
	}
}
