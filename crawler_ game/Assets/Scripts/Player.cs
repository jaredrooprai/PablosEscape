using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject playerPrefab;
	private GameObject instance;
	private int[] playerLocation = {0,0};		// player's current location
	private int[] tempLocation = {0,0};			// used to store  player's previous location for sprite destruction

	private int health;
	private int stamina;

	public Transform playerTransform;

	// Use this for initialization
	public void SetupPlayer () {
		SetPlayerLocation(0,0, playerPrefab);
		health = 100;
		stamina = 100;
	}
	
	// Update is called once per frame
	public void Update () {
	
	}
	
	public void ChangeHealth (int change) {
		health += change;
	}

	public void ChangeStamina (int change) {
		stamina += change;
	}
	
	public int GetHealth () {
		return health;
	}

	public int GetStamina () {
		return stamina;
	}

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
		SetPlayerLocation(playerLocation[0], playerLocation[1], playerPrefab);
	}

	// Updates Player Sprite on map and removes old sprite
	public void SetPlayerLocation(int xcoord, int ycoord, GameObject prefab) {
		int x = xcoord;
		int y = ycoord;

		// using instantiate method here
		instance = Instantiate (prefab, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent (playerTransform);						
	}
}
