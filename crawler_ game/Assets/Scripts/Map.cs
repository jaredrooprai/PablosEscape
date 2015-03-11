using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Map : MonoBehaviour {


	//GameObjects are holding prefabs
	public GameObject floorTile;
	public GameObject exitTile;
	public GameObject VertWallTile, HorizWallTile, BlockingWallTile; // same tile just edited for horizontal stacking
	public GameObject trapTile;
	public GameObject doorPrefab;
	public GameObject keyPrefab;
	public GameObject foodPrefab;

	[HideInInspector]public Transform mapTransform;
	[HideInInspector]public List <Vector3> mapPositions = new List <Vector3>();	//list of grid locations
	// can't use Vector2 even though it uses 2d coord system, because of the Instantiate method.
	
	// Places GameObjects on a map
	public void spawnPrefab (int xcoord, int ycoord, GameObject prefab) {
		int x = xcoord;
		int y = ycoord;

		// using instantiate method here
		GameObject instance = Instantiate (prefab, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent (mapTransform);						
	}



}
