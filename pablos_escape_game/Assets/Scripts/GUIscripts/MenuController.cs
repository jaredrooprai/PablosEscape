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

		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if (success) {
			} else {
				((PlayGamesPlatform) Social.Active).SignOut();
			}
		});
	#endif

	}



	void Update(){
		// if android back button is pressed exit game
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
	}
	public void AboutGameButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("AboutGame");
	}
	
	public void PlayButton(){
		SoundManager.instance.playWalkingFx(click);
		Application.LoadLevel ("LevelSelect");
	}

	public void GooglePlayAchievButton(){
	#if UNITY_EDITOR || UNITY_STANDALONE_WIN
	#elif UNITY_ANDROID
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if (success) {
			} else {
				((PlayGamesPlatform) Social.Active).SignOut();
			}
		});
		Social.ShowAchievementsUI ();
	#endif
		SoundManager.instance.playWalkingFx(click);

	}
}
