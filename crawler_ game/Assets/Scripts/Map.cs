using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Map : MonoBehaviour {


	public GameObject doorSprite;
	public GameObject floorTile;
	public GameObject wallTile;
	public GameObject trapTile;
	public GameObject keySprite;
	public GameObject foodIteam;
	public Transform transformIt;

	// can't use Vector2 even though it uses 2d coord system, because of the Instantiate method.
	public List <Vector3> mapPositions = new List <Vector3>();	//list of grid locations



	// spawns iteam 
	public void spawn_item (int x, int y, GameObject GO) {
		int xcoord = x;
		int ycoord = y;
		GameObject toInsta = GO;
		GameObject instance = Instantiate (toInsta, new Vector3 (xcoord, ycoord, 0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent (transformIt);						
	}

}
