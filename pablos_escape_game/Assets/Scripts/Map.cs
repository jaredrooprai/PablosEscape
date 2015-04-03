using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Map : MonoBehaviour {


	//GameObjects are holding prefabs
	public GameObject floorTile;
	public GameObject cementWall; 
	public GameObject woodBox; // same tile just edited for horizontal stacking
	public GameObject trapTile;
	public GameObject spiderWeb;
	public GameObject milkPrefab;
	public GameObject portalPrefab;

	public GameObject whiteKeyPrefab;
	public GameObject whiteGatePrefab;
	
	public GameObject redKeyPrefab;
	public GameObject redGatePrefab;

	public GameObject blueKeyPrefab;
	public GameObject blueGatePrefab;

	public GameObject goldKeyPrefab;
	public GameObject goldGatePrefab;

	// can't use Vector2 even though it uses 2d coord system, because of the Instantiate method.
	
	// Places GameObjects on a map
	public void spawnPrefab (int xcoord, int ycoord, GameObject prefab) {
		int x = xcoord;
		int y = ycoord;

		// using instantiate method here
		Instantiate (prefab, new Vector3 (x, y, 0f), Quaternion.identity);
	}


}
