using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {
	
	// health objects
	private GameObject heart1;	//
	private GameObject heart2;	//
	private GameObject heart3;	//
	private GameObject heart4;	//
	private GameObject heart5;	//
	
	// key objects 
	private GameObject key1;	//
	private GameObject key2;	//
	private GameObject key3;	//
	private GameObject key4;	//
	private GameObject key5;	//
	
	
	// Use this for initialization
	void Awake () {
		// Finding the game objects 
		heart1 = GameObject.Find ("heart20");	//
		heart2 = GameObject.Find ("heart40");	//
		heart3= GameObject.Find ("heart60");	//
		heart4 = GameObject.Find ("heart80");	//
		heart5 = GameObject.Find ("heart100");	//
		key1 = GameObject.Find ("key1");		//
		key2 = GameObject.Find ("key2");		//
		key3 = GameObject.Find ("key3");		//	
		key4 = GameObject.Find ("key4");		//
		key5 = GameObject.Find ("key5");		//
		
		// player won't have these game objects at the start,
		// turned off 
	}
	
	// toggles to show or not show the heart health objects on the screen
	public void toggleHeart_1 (bool toggle){
		heart1.SetActive (toggle);
	}
	public void toggleHeart_2 (bool toggle){
		heart2.SetActive (toggle);
	}
	public void toggleHeart_3 (bool toggle){
		heart3.SetActive (toggle);
	}
	public void toggleHeart_4 (bool toggle){
		heart4.SetActive (toggle);
	}
	public void toggleHeart_5 (bool toggle){
		heart5.SetActive (toggle);
	}
	
	
	// toggles to show or not show the key objects on the screen
	public void toggleKey_1 (bool toggle){
		key1.SetActive (toggle);
	}
	public void toggleKey_2 (bool toggle){
		key2.SetActive (toggle);
	}
	public void toggleKey_3 (bool toggle){
		key3.SetActive (toggle);
	}
	public void toggleKey_4 (bool toggle){
		key4.SetActive (toggle);
	}
	public void toggleKey_5 (bool toggle){
		key5.SetActive (toggle);
	}
}