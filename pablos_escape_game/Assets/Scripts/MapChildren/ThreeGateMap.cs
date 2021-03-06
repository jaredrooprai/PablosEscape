﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ThreeGateMap : Map 
{ 
	private int columns = 10;
	private int rows = 20; 
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		mapTransform = new GameObject ("Map").transform;
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}
	

	
	//Sets up the floor and the walls
	void setupTiles () {
		//will contain wall prefab or floor prefab
		GameObject tile;
		
		for (int x = -1; x <= columns + 1; x++) 
		{ 
			for (int y = -1; y <= rows + 1; y++)
			{	
				
				
				if ( x >= 0 && x <= 3 && y >= 5 && y <= 15) {
					tile = cementWall;
				}
				else if ( x <= columns && x >= 7 && y >= 5 && y <= 15)
					tile = cementWall;
				else if ( x >= 0 && x <= 2 && y >= 6 && y <= 14)
					tile = null;

				else if( x == -1 || x == columns + 1 || y == -1 || y == rows + 1){
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
		spawnPrefab (7, 0, whiteKeyPrefab);
		spawnPrefab (10, 4, blueKeyPrefab);
		spawnPrefab (3, 0, redKeyPrefab);

		spawnPrefab (2, 0, trapTile);
		spawnPrefab (2, 0, spiderWeb);

		spawnPrefab (0, 3, milkPrefab);
		spawnPrefab (9, 1, milkPrefab);


		spawnPrefab (0, 2, whiteGatePrefab);
		spawnPrefab (1, 2, woodBox);
		spawnPrefab (2, 2, woodBox);
		spawnPrefab (3, 2, woodBox);
		spawnPrefab (4, 2, woodBox);
		spawnPrefab (5, 2, woodBox);
		spawnPrefab (6, 2, woodBox);
		spawnPrefab (7, 2, woodBox);
		spawnPrefab (8, 2, woodBox);
		spawnPrefab (9, 2, woodBox);
		spawnPrefab (10, 2, woodBox);
		

		spawnPrefab (4, 4, woodBox);
		spawnPrefab (5, 4, woodBox);
		spawnPrefab (6, 4, blueGatePrefab);
		
		spawnPrefab (4, 6, redGatePrefab);
		spawnPrefab (5, 6, woodBox);
		spawnPrefab (6, 6, woodBox);
		spawnPrefab (10,20, portalPrefab);


		int spiderTemp = 20;
		while (spiderTemp > 7) {
			spawnPrefab (5, spiderTemp, trapTile);
			spawnPrefab (5, spiderTemp, spiderWeb);

			spiderTemp--;
		}
		
	}
	
}