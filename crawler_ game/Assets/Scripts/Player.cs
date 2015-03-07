using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject playerPrefab;
	private GameObject instance;
	private int[] playerLocation = {0,0};		// player's current location
	private int[] tempLocation = {0,0};			// used to store  player's previous location for sprite destruction

	private int health;
	private int stamina;

	// Use this for initialization
	public void SetupPlayer () {
		UpdatePlayerLocation(0,0);
		health = 100;
		stamina = 100;
	}
	
	// Update is called once per frame
	public void Update () {
	
	}

	// used to set a change (positive/negative) to health
	public void ChangeHealth (int change) {
		health += change;
	}
	
	// used to set a change (positive/negative) to stamina
	public void ChangeStamina (int change) {
		stamina += change;
	}

	// used to retrieve health value
	public int GetHealth () {
		return health;
	}
	
	// used to retrieve stamina value
	public int GetStamina () {
		return stamina;
	}
	
	// used to retrieve player location values
	public int[] GetLocation () {
		return playerLocation;
	}

	// Check to see if player-move input is valid
	public void CheckMove (int mapMaxColumn, int mapMaxRow, int[] direction) {
		if (direction[0] + playerLocation[0] <= mapMaxColumn && direction[1] + playerLocation[1] <= mapMaxRow) {
			tempLocation[0] = playerLocation[0];
			tempLocation[1] = playerLocation[1];
			playerLocation[0] += direction[0];
			playerLocation[1] += direction[1];
		}
		UpdatePlayerLocation(playerLocation[0], playerLocation[1]);
	}

	// Updates Player Sprite on map and removes old sprite
	public void UpdatePlayerLocation(int x, int y) {
		// remove previous instance of player
		Destroy(instance);
		// create new instance of player
		instance = Instantiate (playerPrefab, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;						
	}
}
