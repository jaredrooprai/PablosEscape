using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MapOne : Map 
{

	private int rows = 5; 
	private int columns = 20;

	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupGrid ();				// call method to setup grid
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}


	void setupGrid (){
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

	//Sets up the floor and the walls
	void setupTiles () {
		//will contain wall prefab or floor prefab		
		GameObject tile;
 
		for (int x = -1; x <= columns + 1; x++) 
		{ 
			for (int y = -1; y <= rows + 1; y++)
			{	
				// if coordinates == boundaries, spawn wall tile
				if ( x == -1 || y == -1 || x == columns + 1 || y == rows + 1 )  
					tile = wallTile; 
				// else spawn floor tile
				else 		
					tile = floorTile; 

				spawnPrefab (x, y, tile);				
			}
		}
	}

	// Method to add items into the map using parent spawnItem method
	void setupItems(){
		spawnPrefab (3, 3, keyPrefab);				
	}


}

