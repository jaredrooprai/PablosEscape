using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;	


	public AudioSource voicefx;
	public AudioSource walkingfx;
	public AudioSource music;

	void Awake () {
		// checks if this is not null so it won't make two game managers, or make two boards
		if (instance == null) {
			instance = this;
		
		} else if (instance != this) {
			Destroy (gameObject);    
		}
		DontDestroyOnLoad (gameObject);

	}

	public void playWalkingFx (AudioClip clip){
		walkingfx.clip = clip;
		walkingfx.Play ();
	}

	public void randomWalkingFx (params AudioClip [] clips){
		int randomSound = Random.Range (0, clips.Length);
		walkingfx.clip = clips[randomSound];
		walkingfx.Play();
	}
	                                         

	public void playVoiceFx (AudioClip clip){
		voicefx.clip = clip;
		voicefx.Play ();
	}

	public void randomVoiceFx(params AudioClip [] clips){
		int randomSound = Random.Range (0, clips.Length);
		voicefx.clip = clips[randomSound];
		voicefx.Play();
	}
}
