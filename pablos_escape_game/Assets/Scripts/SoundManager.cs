using UnityEngine;
using System.Collections;

/// <summary>
/// Sound manager.
/// Has methods that can be passed sounds and will play them using Audio Sources
/// </summary>

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;	

	// voice handles player voice sounds
	public AudioSource voicefx;
	// walking handles step sounds and GUI sound ****
	// becuse a user can't walk and use gui at the same time
	public AudioSource walkingfx;
	// background music
	public AudioSource music;
	// Sounds for ending level and completeing level
	public AudioSource ambfx;
	// sounds gates mak
	public AudioSource gatefx;
	// sound for any alerts
	public AudioSource alertfx;

	void Awake () {
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
		
		} else if (instance != this) {
			Destroy (gameObject);    
		}
		DontDestroyOnLoad (gameObject);

	}

	// For plaything through alert audio source
	public void playAlertFx (AudioClip clip){
		alertfx.clip = clip;
		alertfx.Play ();
	}

	// for playing through walking audio source
	public void playWalkingFx (AudioClip clip){
		walkingfx.clip = clip;
		walkingfx.Play ();
	}

	// for randomizing through walking audio source
	public void randomWalkingFx (params AudioClip [] clips){
		int randomSound = Random.Range (0, clips.Length);
		walkingfx.clip = clips[randomSound];
		walkingfx.Play();
	}
	    
	// for player voice audio source
	public void playVoiceFx (AudioClip clip){
		voicefx.clip = clip;
		voicefx.Play ();
	}

	// for playing through random voice audio source
	public void randomVoiceFx(params AudioClip [] clips){
		int randomSound = Random.Range (0, clips.Length);
		voicefx.clip = clips[randomSound];
		voicefx.Play();
	}

	// any added sounds thats not game music
	public void playAmbFx (AudioClip clip){
		ambfx.clip = clip;
		ambfx.Play ();
	}

	// sounds for gate disapearing
	public void playGatefx (params AudioClip [] clips){
		int randomSound = Random.Range (0, clips.Length);
		gatefx.clip = clips[randomSound];
		gatefx.Play();
	}
}
