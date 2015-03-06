using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MapOne : Map 
{
	public void setupScene ()
	{
		setupGrid ();
		spawnTiles ();
	}

	void setupGrid () {
		transformIt = new GameObject ("Board").transform;
		mapPositions.Clear ();
		for (int x = 0; x < 3; x++) {
			for (int y = 0; y < 3; y++) {
				mapPositions.Add (new Vector3 (x, y, 0f));	//z coord is set to 0f because of 2d grid
				
			}
		}
	}
	
	void spawnTiles () {
		for(int x = 0; x < 3; x++)
		{
			for(int y = 0; y < 3; y++)
			{	
				GameObject toInstantiate = floorTile;
				GameObject instance = Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (transformIt);
			}
		}
	}
	
}

