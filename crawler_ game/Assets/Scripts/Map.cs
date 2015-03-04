using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Map : MonoBehaviour {


	public GameObject doorTile;
	public GameObject floorTile;
	public GameObject wallTile;
	public GameObject trapTile;
	public GameObject foodIteam;
	
	public Transform transformers_robots_in_disguise;


	// can't use Vector2 even though it uses 2d coord system, because of the Instantiate method.
	public List <Vector3> mapPositions = new List <Vector3>();	// A list of possible locations to place items

}
