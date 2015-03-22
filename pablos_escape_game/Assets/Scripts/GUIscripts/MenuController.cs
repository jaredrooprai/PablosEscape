using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuController : MonoBehaviour {

	public AudioClip click;

	void Awake(){
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
	}

	void Start(){
		Social.localUser.Authenticate (
			(bool success) => {
			// handle success or failure
		});
	}

	void Update(){
		// if android back button is pressed exit game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	public void AboutGameButton(){
		SoundManager.instance.playVoiceFx(click);
		Application.LoadLevel ("AboutGame");
	}
	
	public void PlayButton(){
		SoundManager.instance.playVoiceFx(click);
		Application.LoadLevel ("Play");
	}

	public void GooglePlayAchievButton(){
		SoundManager.instance.playVoiceFx(click);
		Social.ShowAchievementsUI ();
	}
}
