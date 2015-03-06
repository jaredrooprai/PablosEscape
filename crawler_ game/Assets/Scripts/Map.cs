using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Map : MonoBehaviour {


	public GameObject doorTile;
	public GameObject floorTile;
	public GameObject wallTile;
	public GameObject trapTile;
	public GameObject foodIteam;
	
	public Transform transformIt;


	// can't use Vector2 even though it uses 2d coord system, because of the Instantiate method.
	public List <Vector3> mapPositions = new List <Vector3>();	//list of grid locations

}
