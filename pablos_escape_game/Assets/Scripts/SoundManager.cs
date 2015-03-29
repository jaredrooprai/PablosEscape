using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance = null;	


	public AudioSource voicefx;
	public AudioSource walkingfx;
	public AudioSource music;
	public AudioSource ambfx;
	public AudioSource gatefx;
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

	public void playAlertFx (AudioClip clip){
		alertfx.clip = clip;
		alertfx.Play ();
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

	public void playAmbFx (AudioClip clip){
		ambfx.clip = clip;
		ambfx.Play ();
	}

	public void playGatefx (params AudioClip [] clips){
		int randomSound = Random.Range (0, clips.Length);
		gatefx.clip = clips[randomSound];
		gatefx.Play();
	}
}
