using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// Parent class that holds Games gameobjects and handls object spawning
/// This class is not a map itself, but its children are
/// </summary>

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

	[HideInInspector]public Transform mapTransform;

	// Places GameObjects on a map
	public void spawnPrefab (int xcoord, int ycoord, GameObject prefab) {
		int x = xcoord;
		int y = ycoord;

		// using instantiate method here
		GameObject instance = Instantiate (prefab, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
		// puts it under Map in board
		instance.transform.SetParent (mapTransform);						
	}


}
