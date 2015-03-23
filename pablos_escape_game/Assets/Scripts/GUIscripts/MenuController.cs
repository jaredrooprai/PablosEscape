using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class MenuController : MonoBehaviour {

	public AudioClip click;

	void Awake(){
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
#elif UNITY_ANDROID
		PlayGamesPlatform.DebugLogEnabled = true;
		PlayGamesPlatform.Activate ();
#endif

	}

	void Start(){
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
#elif UNITY_ANDROID
		Social.localUser.Authenticate ( (bool success) => {});
#endif
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
		Social.localUser.Authenticate (
			(bool success) => {
			// handle success or failure
		});

		SoundManager.instance.playVoiceFx(click);
		Social.ShowAchievementsUI ();
	}
}
