using UnityEngine;
using System.Collections;

public class LevelSelectController : MonoBehaviour {

	private GameObject level2lock;
	private GameObject level3lock;
	private GameObject level4lock;
	private GameObject level5lock;
	private GameObject level6lock;
	private GameObject level7lock;
	private GameObject level8lock;
	private GameObject level9lock;
	private GameObject level10lock;


	
	public AudioClip click;
	
	
	// Use this for initialization
	void Start () {
		level2lock = GameObject.Find ("level2lock");
		level3lock = GameObject.Find ("level3lock");
		level4lock = GameObject.Find ("level4lock");
		level5lock = GameObject.Find ("level5lock");
		level6lock = GameObject.Find ("level6lock");
		level7lock = GameObject.Find ("level7lock");
		level8lock = GameObject.Find ("level8lock");
		level9lock = GameObject.Find ("level9lock");
		level10lock = GameObject.Find ("level10lock");

		checkLock (2, level2lock);
		checkLock (3, level3lock);
		checkLock (4, level4lock);
		checkLock (5, level5lock);
		checkLock (6, level6lock);
		checkLock (7, level7lock);
		checkLock (8, level8lock);
		checkLock (9, level9lock);
		checkLock (10, level10lock);

	}
	
	// Update is called once per frame
	void Update () {
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			SoundManager.instance.playWalkingFx(click);
			StartCoroutine ("loadScene","MainMenu");
		}
	}
	





	public void BackButton(){
		SoundManager.instance.playWalkingFx(click);
		StartCoroutine ("loadScene","MainMenu");
	}
	

	public void TutorialButton(){
		SoundManager.instance.playWalkingFx (click);
		PlayerPrefs.SetInt ("SavedLevel", 1);
		StartCoroutine ("loadScene","Tutorial");
	}

	public void level2Button(){
		StartCoroutine ("loadScene",2);
	}
	
	public void level3Button(){
		StartCoroutine ("loadScene",3 );
	}
	
	public void level4Button(){
		StartCoroutine ("loadScene",4 );
	}

	public void level5Button(){
		StartCoroutine ("loadScene", 5);
	}
	

	public void level6Button(){
		StartCoroutine ("loadScene",6 );
	}

	public void level7Button(){
		StartCoroutine ("loadScene",7 );
	}

	public void level8Button(){
		StartCoroutine ("loadScene", 8);
	}

	public void level9Button(){
		StartCoroutine ("loadScene", 9 );
	}
	
	public void level10Button(){
		StartCoroutine ("loadScene",10 );
	}


	private void checkLock(int level, GameObject levelLock){
		if (PlayerPrefs.GetInt ("HighestLevel") >= level)
			levelLock.SetActive (false);
		else
			levelLock.SetActive (true);
	}
	

	IEnumerator checkButton(int level){

		if (PlayerPrefs.GetInt ("HighestLevel") >= level) {

			SoundManager.instance.playWalkingFx (click);
			PlayerPrefs.SetInt ("SavedLevel", level);

			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
			Application.LoadLevel ("Game");
		}
	}

	IEnumerator loadScene(int level){
		
		if (PlayerPrefs.GetInt ("HighestLevel") >= level) {
			
			SoundManager.instance.playWalkingFx (click);
			PlayerPrefs.SetInt ("SavedLevel", level);
			
			float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
			yield return new WaitForSeconds (fadeTime);
			Application.LoadLevel ("Game");
		}
	}

	IEnumerator loadScene(string sceneName){
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (sceneName);
		
	}
	

}
