﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MapOne : Map 
{ 
	private int columns = 4;
	private int rows = 7; 

	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupGrid ();				// call method to setup grid
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}


	void setupGrid (){
		mapTransform = new GameObject ("Board").transform;
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
			
					// placing down a tile which represents the next room
				/*
				if (x == columns && y == rows)
					tile = exitTile;
					*/
				// depening on where the tile is placed it will either spawn a
				// horizontal brick pattern or vertical brick battern
				if( x == -1 || x == columns + 1 || y == -1 || y == rows + 1){
					tile = cementWall;
				}
				else 		// else spawn floor normal floor tile
					tile = floorTile; 

				spawnPrefab (x, y, tile);				
			}
		}
	}

	// Method to add items into the map using parent spawnItem method
	void setupItems(){
		spawnPrefab (4, 0, whiteKeyPrefab);
		spawnPrefab (3, 0, tealKeyPrefab);
		spawnPrefab (2, 0, goldKeyPrefab);
		spawnPrefab (1, 1, spiderWeb);


		spawnPrefab (0, 2, whiteGatePrefab);
		spawnPrefab (1, 2, woodBox);
		spawnPrefab (2, 2, woodBox);
		spawnPrefab (3, 2, woodBox);
		spawnPrefab (4, 2, woodBox);

		spawnPrefab (0, 4, woodBox);
		spawnPrefab (1, 4, woodBox);
		spawnPrefab (2, 4, woodBox);
		spawnPrefab (3, 4, woodBox);
		spawnPrefab (4, 4, tealGatePrefab);

		spawnPrefab (0, 6, goldGatePrefab);
		spawnPrefab (1, 6, woodBox);
		spawnPrefab (2, 6, woodBox);
		spawnPrefab (3, 6, woodBox);
		spawnPrefab (4, 6, woodBox);


	}

}

