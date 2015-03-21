using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Map4: Map 
{ 
	private int rows = 30;
	private int columns = 30; 
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupGrid ();				// call method to setup grid
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}
	
	
	void setupGrid (){
		mapTransform = new GameObject ("Map").transform;
		mapPositions.Clear ();								// clear the list
		for (int x = -1; x <= rows + 1; x++) 			// adding row items into list
		{
			for (int y = -1; y <= columns + 1; y++) 			// adding column items to list
			{
				if (x >= 0 && x <= 3 && y >= 5 && y <= 15) 
					mapPositions.Add (new Vector3 (x, y, 0f));	// z coord is set to 0f because of 2d grid
			}
		}
	}
	
	//Sets up the floor and the walls
	void setupTiles () {
		//will contain wall prefab or floor prefab
		GameObject tile;
		
		for (int x = -1; x <= rows + 1; x++) 
		{ 
			for (int y = -1; y <= columns + 1; y++)
			{	
				if( x == -1 || x == columns + 1 || y == -1 || y == rows + 1){
					tile = cementWall;
				}
				
				else if ((x == 3 && y >= 0 && y <= 7) || (x >= 0 && x <= 7 && y == 10) || (x >= 3 && x <= 7 && y == 7) || (x == 2 && y == 4) || (x == 0 && y == 4)) {
					tile = cementWall;
				}
				
				else if ((x == 9 && y >= 1 && y <= 12) || (x >= 1 && x <= 8 && y == 12) || (x == 10 && y == 1) || (x >= 12 && x <= 13 && y == 1) || (x == 13 && y >= 1 && y <= 5) || (x >= 10 && x <= 13 && y == 5)){
					tile = cementWall;
				}
				
				//For Third top portion of map	
				else if ((x == 1 && y >= 12 && y <= 17) || (x == 1 && y >= 19 && y <= 24) || (x == 1 && y >= 26 && y <= 31)){
					tile = cementWall;
				}
				
				else if ((x >= 2 && x <= 6 && y >= 19 && y <= 24) || (x >= 5 && x <= 7 && y >= 23 && y <= 26) || (x >= 2 && x <= 4 && y == 17) || (x == 2 && y >= 13 && y <=16) || (x >= 4 && x <= 6 && y >= 13 && y <= 15) || (x >= 2 && x <= 7 && y >= 28 && y <= columns+1) || (x >= 2 && x <= 3 && y >= 26 && y <= 27) || (x >= 6 & x <= 12 && y == 17) || (x >= 10 && x <= 11 && y >= 19 && y <= 21) || (x >= 7 && x <= 9 && y == 19) || (x >= 8 && x <= 9 && y == 21) || (x >= 9 && x <= 14 && y >= 23 && y <= 27) || (x >= 13 && x <= 18 && y >= 19 && y <= 22) || (x >= 20 && x <= 25 && y >= 19 && y <= 28) || (x >= 16 && x <= 19 && y >= 24 && y <= 27) || (x >= 9 && x <= 18 && y == 29) || (x >= 20 && x <= 30 && y == 30) || (x >= 27 && x <= 28 && y >= 19 && y <= 29) || (x == 29 && y >= 19 && y <= 27) || (x >= 8 && x <= 12 && y >= 13 && y <= 16) || (x >= 12 && x <= 21 && y >= 13 && y <= 17) || (x >= 22 && x <= 25 && y >= 16 && y<= 17) || (x >= 23 && x <= 30 && y >= 13 && y <= 14) || (x >= 27 && x <= 30 && y >= 15 && y <= 17)){
					tile = cementWall;
				}
				
				//Last Section of map
				else if ((x >= 29 && x <= 30 && y >= 8 && y <= 12) || (x >= 27 && x <= 28 && y >= 11 && y <= 12) || (x >= 21 && x <= 23 && y >= 8 && y <= 11) || (x >= 24 && x <= 25 && y == 11) || (x >= 14 && x <= 21 && y >= 11 && y <= 12) || (x >= 14 && x <= 17 && y >= 1 && y <= 5) || (x >= 14 && x <= 15 && y >= 6 && y <= 8) || (x >= 17 && x <= 19 && y >= 8 && y <= 9) || (x == 17 && y == 7)){
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
		
		//First section of map
		spawnPrefab (0, 1, trapTile);
		spawnPrefab (0, 2, trapTile);
		spawnPrefab (0, 3, trapTile);
		
		spawnPrefab(2, 1, trapTile);
		spawnPrefab(2, 2, trapTile);
		spawnPrefab(2, 3, trapTile);

		
		spawnPrefab (2, 2, redKeyPrefab); //First key
		
		spawnPrefab (1, 4, redGatePrefab);
		
		//spawnPrefab (1, 4, tealGatePrefab); //First gate of map
		
		//Second portion of map
		spawnPrefab (8, 8, trapTile);
		spawnPrefab (8, 9, trapTile);
		
		
		spawnPrefab (1, 5, milkPrefab);
		
		//Third bottom portion of map
		spawnPrefab (4, 0, trapTile);
		spawnPrefab (6, 0, trapTile);
		spawnPrefab (8, 0, trapTile);
		spawnPrefab (5, 1, trapTile);
		spawnPrefab (7, 1, trapTile);
		spawnPrefab (4, 2, trapTile);
		spawnPrefab (6, 2, trapTile);
		spawnPrefab (8, 2, trapTile);
		spawnPrefab (5, 3, trapTile);
		spawnPrefab (7, 3, trapTile);
		spawnPrefab (4, 4, trapTile);
		spawnPrefab (6, 4, trapTile);
		spawnPrefab (8, 4, trapTile);
		spawnPrefab (5, 5, trapTile);
		spawnPrefab (7, 5, trapTile);
		spawnPrefab (4, 6, trapTile);
		spawnPrefab (6, 6, trapTile);
		spawnPrefab (8, 6, trapTile);
		
		
		spawnPrefab (5, 4, milkPrefab);
		spawnPrefab (5, 6, milkPrefab);
		spawnPrefab (8, 5, milkPrefab);
		spawnPrefab (4, 3, milkPrefab);
		spawnPrefab (5, 0, milkPrefab);
		spawnPrefab (7, 0, milkPrefab);
		
		
		spawnPrefab (4, 1, blueKeyPrefab);
		spawnPrefab (8, 3, goldKeyPrefab);
		
		spawnPrefab (9, 0, blueGatePrefab);
		
		//Third Top portion of map
		spawnPrefab (19, 28, woodBox);
		
		spawnPrefab (8, 20, milkPrefab);
		spawnPrefab (3, 14, milkPrefab);
		spawnPrefab (0, 30, milkPrefab);
		spawnPrefab (5, 16, milkPrefab);
		spawnPrefab (13, 28, milkPrefab);
		spawnPrefab (30, 29, milkPrefab);
		spawnPrefab (30, 27, milkPrefab);
		
		
		spawnPrefab (3, 13, redKeyPrefab);
		spawnPrefab (7, 16, whiteKeyPrefab);
		spawnPrefab (7, 13, goldKeyPrefab);
		spawnPrefab (9, 20, goldKeyPrefab);
		spawnPrefab (19, 30, goldKeyPrefab);
		spawnPrefab (29, 28, blueKeyPrefab);
		
		
		spawnPrefab (3, 15, trapTile);
		spawnPrefab (7, 14, trapTile);
		spawnPrefab (5, 17, trapTile);
		spawnPrefab (12, 18, trapTile);
		spawnPrefab (7, 21, trapTile);
		spawnPrefab (8, 30, trapTile);
		spawnPrefab (15, 28, trapTile);
		spawnPrefab (23, 18, trapTile);
		spawnPrefab (24, 18, trapTile);
		spawnPrefab (25, 18, trapTile);
		spawnPrefab (29, 29, trapTile);
		spawnPrefab (30, 28, trapTile);
			
		
		spawnPrefab (14, 18, whiteGatePrefab);
		spawnPrefab (7, 20, redGatePrefab);
		spawnPrefab (8, 28, goldGatePrefab);
		spawnPrefab (20, 29, goldGatePrefab);
		
		//Troll Third Bottom portion of map
		spawnPrefab (11, 1, goldGatePrefab);
		
		spawnPrefab (10, 2, whiteKeyPrefab);
		spawnPrefab (11, 2, whiteKeyPrefab);
		spawnPrefab (12, 2, whiteKeyPrefab);
		spawnPrefab (10, 3, blueKeyPrefab);
		spawnPrefab (11, 3, blueKeyPrefab);
		spawnPrefab (12, 3, blueKeyPrefab);
		spawnPrefab (10, 4, goldKeyPrefab);
		spawnPrefab (11, 4, goldKeyPrefab);
		spawnPrefab (12, 4, goldKeyPrefab);
		
		//Last Section of the map
		spawnPrefab (11, 9, portalPrefab);


		spawnPrefab (22, 1, whiteKeyPrefab);
		spawnPrefab (30, 0, redKeyPrefab);
		
		
		spawnPrefab (25, 8, woodBox);
		spawnPrefab (25, 8, woodBox);
		spawnPrefab (27, 9, woodBox);
		spawnPrefab (27, 8, woodBox);
		spawnPrefab (29, 7, woodBox);
		spawnPrefab (27, 7, woodBox);
		spawnPrefab (25, 7, woodBox);
		spawnPrefab (21, 7, woodBox);
		spawnPrefab (19, 7, woodBox);
		spawnPrefab (27, 6, woodBox);
		spawnPrefab (25, 6, woodBox);
		spawnPrefab (24, 6, woodBox);
		spawnPrefab (23, 6, woodBox);
		spawnPrefab (21, 6, woodBox);
		spawnPrefab (29, 5, woodBox);
		spawnPrefab (28, 5, woodBox);
		spawnPrefab (27, 5, woodBox);
		spawnPrefab (25, 5, woodBox);
		spawnPrefab (23, 5, woodBox);
		spawnPrefab (21, 5, woodBox);
		spawnPrefab (19, 5, woodBox);
		spawnPrefab (29, 3, woodBox);
		spawnPrefab (26, 3, woodBox);
		spawnPrefab (23, 3, woodBox);
		spawnPrefab (20, 3, woodBox);
		spawnPrefab (28, 2, woodBox);
		spawnPrefab (25, 2, woodBox);
		spawnPrefab (22, 2, woodBox);
		spawnPrefab (19, 2, woodBox);
		spawnPrefab (29, 1, woodBox);
		spawnPrefab (25, 1, woodBox);
		spawnPrefab (21, 1, woodBox);
		spawnPrefab (27, 0, woodBox);
		spawnPrefab (22, 0, woodBox);
		
		
		spawnPrefab (30, 7, milkPrefab);
		spawnPrefab (18, 7, milkPrefab);
		spawnPrefab (24, 5, milkPrefab);
		spawnPrefab (25, 3, milkPrefab);
		spawnPrefab (18, 3, milkPrefab);
		spawnPrefab (26, 2, milkPrefab);
		spawnPrefab (28, 1, milkPrefab);	
		
		
		spawnPrefab (20, 6, trapTile);
		spawnPrefab (19, 6, trapTile);
		spawnPrefab (30, 5, trapTile);
		spawnPrefab (20, 5, trapTile);
		spawnPrefab (18, 5, trapTile);
		spawnPrefab (20, 4, trapTile);
		spawnPrefab (19, 4, trapTile);
		spawnPrefab (18, 4, trapTile);
		spawnPrefab (19, 3, trapTile);
		spawnPrefab (24, 2, trapTile);
		spawnPrefab (18, 2, trapTile);
		spawnPrefab (30, 1, trapTile);
		spawnPrefab (23, 1, trapTile);
		spawnPrefab (29, 0, trapTile);
		spawnPrefab (26, 0, trapTile);
		spawnPrefab (24, 0, trapTile);
	}
	
}