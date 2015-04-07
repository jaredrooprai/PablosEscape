using UnityEngine;
using System.Collections;



/// <summary>
/// Player health.
/// Class handles player health and controls player heart gui
/// </summary>



public static class PlayerHealth{


	//player health value
	public static int health;


	// Increases Health by 1
	public static void incHealth(){
		health++;
	}

	// Decreases Health by 1
	public static void decHealth(){
		health--;
	}



	//  updates health HUD in playerHUD class and makes sure that the health stays in bound. ( 0 <= health <= 5
	public static void manageHealth(){
		if (health > 5) 
			health = 5;
		PlayerHUD.toggleHeart_1 (checkHealth (1));
		PlayerHUD.toggleHeart_2 (checkHealth (2));
		PlayerHUD.toggleHeart_3 (checkHealth (3));
		PlayerHUD.toggleHeart_4 (checkHealth (4));
		PlayerHUD.toggleHeart_5 (checkHealth (5));
	}


	// returns true if player should be dead, that is, if he has 0 and less health value
	public static bool IsPlayerDead(){
		if (health < 1)
			return true;
		else
			return false;
	}


	// method returns true or false if the GUI for said heart number should be on or off
	public static bool checkHealth(int heartNumber){
		if (health >= heartNumber)
			return true;
		else
			return false;
	}


}
