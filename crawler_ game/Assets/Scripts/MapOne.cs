using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MapOne : Map 
{

	private int rows = 5; 
	private int columns = 20;


	public void setupScene ()
	{
		setupGrid ();				// call method to setup grid
		spawn_wall_floor ();		// generate wall and floor tiles
	}

	void setupGrid () 
	{
		transformIt = new GameObject ("Board").transform;
		mapPositions.Clear ();								// clear the list
		for (int x = -1; x <= columns + 1; x++) 			// adding row items into list
		{
			for (int y = -1; y <= rows + 1; y++) 			// adding column items to list
			{
				mapPositions.Add (new Vector3 (x, y, 0f));	// z coord is set to 0f because of 2d grid
			}
		}
	}
	
	void spawn_wall_floor () {

		for (int x = -1; x <= columns + 1; x++) 
		{
			for (int y = -1; y <= rows + 1; y++)
			{	
				GameObject toInsta;												// initialize GameObject instance

				if ( x == -1 || y == -1 || x == columns + 1 || y == rows + 1 )  // if coordinates == boundaries, spawn wall tile
					toInsta = wallTile; 
				else 															// else spawn floor tile
					toInsta = floorTile; 
		
				GameObject instance = Instantiate (toInsta, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (transformIt);						// instantiate wall/floor tile
			}
		}
	}

	void spawn_door () {
		int doorX;
		int doorY;

		GameObject toInsta = doorSprite;

		GameObject instance = Instantiate (toInsta, new Vector3 (doorX, doorY, 0f), Quaternion.identity) as GameObject;
		instance.transform.SetParent (transformIt);						// instantiate wall/floor tile
		

		// spawn door tile after map is generated
	}
}

