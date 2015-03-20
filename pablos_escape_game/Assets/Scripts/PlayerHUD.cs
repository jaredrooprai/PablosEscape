using UnityEngine;
using System.Collections;

public static class PlayerHUD {
	
	// health objects
	private static GameObject heart1;	
	private static GameObject heart2;	
	private static GameObject heart3;	
	private static GameObject heart4;	
	private static GameObject heart5;	
	
	// key objects 
	private static GameObject key1;	
	private static GameObject key2;	
	private static GameObject key3;

	
	
	// Use this for initialization
	public static void setVariables () {
		// Finding the game objects 
		heart1 = GameObject.Find ("heart1");	
		heart2 = GameObject.Find ("heart2");	
		heart3 = GameObject.Find ("heart3");	
		heart4 = GameObject.Find ("heart4");	
		heart5 = GameObject.Find ("heart5");	
		key1 = GameObject.Find ("key1");		
		key2 = GameObject.Find ("key2");		
		key3 = GameObject.Find ("key3");	
			// player won't have these game objects at the start,
		// turned off 
	}


	// right before player dies call this for some reason fixes issue
	public static void activateAll (){
		toggleHeart_1 (true);
		toggleHeart_2 (true);
		toggleHeart_3 (true);
		toggleHeart_4 (true);
		toggleHeart_5 (true);
		toggleKey_1 (true);
		toggleKey_2 (true);
		toggleKey_3 (true);

	}





	// toggles to show or not show the heart health objects on the screen
	public static void toggleHeart_1 (bool toggle){
		if (heart1 != null) {
			heart1.SetActive (toggle);
		}
	}

	public static void toggleHeart_2 (bool toggle){
		if (heart2 != null) {
			heart2.SetActive (toggle);
		}	}

	public static void toggleHeart_3 (bool toggle){
		if (heart3 != null) {
			heart3.SetActive (toggle);
		}	}

	public static void toggleHeart_4 (bool toggle){
		if (heart4 != null) {
			heart4.SetActive (toggle);
		}	}

	public static void toggleHeart_5 (bool toggle){
		if (heart5 != null) {
			heart5.SetActive (toggle);
		}	}
	
	
	// toggles to show or not show the key objects on the screen
	public static void toggleKey_1 (bool toggle){
		if (key1 != null){
			key1.SetActive (toggle);
		}
	}

	public static void toggleKey_2 (bool toggle){
		if (key2 != null){
			key2.SetActive (toggle);
		}
	}

	public static void toggleKey_3 (bool toggle){
		if (key3 != null){
			key3.SetActive (toggle);
		}
	}

}