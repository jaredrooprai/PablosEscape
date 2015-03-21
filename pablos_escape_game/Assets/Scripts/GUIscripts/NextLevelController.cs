using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevelController : MonoBehaviour {
	
	//private GameObject nextLevelButton;
	public AudioClip laugh;
	public AudioClip click;

	
	
	// Use this for initialization
	void Start () {
		SoundManager.instance.playVoiceFx(laugh);

		GameObject.Find ("NextLevel").GetComponentInChildren<Text>().text = "Level " + PlayerPrefs.GetInt("SavedLevel");
			
	}
	
	// Update is called once per frame
	void Update () {
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			Application.LoadLevel("MainMenu");
		}
		
	}

	public void PlayNextLevelButon(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("Game");
		
	}
	
	public void MenuButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("MainMenu");
	}

}