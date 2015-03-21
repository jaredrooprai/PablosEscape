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
	private static GameObject whiteKey;	
	private static GameObject redKey;	
	private static GameObject blueKey;
	private static GameObject goldKey;

	private static GameObject curtain;



	
	
	// Use this for initialization
	public static void setVariables () {
		// Finding the game objects 
		heart1 = GameObject.Find ("heart1");	
		heart2 = GameObject.Find ("heart2");	
		heart3 = GameObject.Find ("heart3");	
		heart4 = GameObject.Find ("heart4");	
		heart5 = GameObject.Find ("heart5");	
		whiteKey = GameObject.Find ("whiteKey");		
		redKey = GameObject.Find ("redKey");		
		blueKey = GameObject.Find ("blueKey");
		goldKey = GameObject.Find ("goldKey");	

			// player won't have these game objects at the start,
		// turned off 
	}

	public static void toggleCurtain(bool toggle){
		curtain = GameObject.Find ("curtain");	

		if (curtain != null) {
			curtain.SetActive(toggle);
		}
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
	public static void toggleWhiteKey (bool toggle){
		if (whiteKey != null){
			whiteKey.SetActive (toggle);
		}
	}

	public static void toggleRedKey (bool toggle){
		if (redKey != null){
			redKey.SetActive (toggle);
		}
	}
	

	public static void toggleBlueKey (bool toggle){
		if (blueKey != null){
			blueKey.SetActive (toggle);
		}
	}

	public static void toggleGoldKey (bool toggle){
		if (goldKey != null){
			goldKey.SetActive (toggle);
		}
	}

}