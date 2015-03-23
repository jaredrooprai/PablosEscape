using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Map3 : Map 
{ 
	private int rows = 22;
	private int columns = 15; 
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupItems();
		setupGrid ();				// call method to setup grid
		setupTiles ();		// generate wall and floor tiles
		
	}
	
	
	void setupGrid (){
		mapTransform = new GameObject ("Map").transform;
		mapPositions.Clear ();								// clear the list
		for (int x = -15; x <= columns + 1; x++) 			// adding row items into list
		{
			for (int y = -22; y <= rows + 1; y++) 			// adding column items to list
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
		
		spawnPrefab (1, 2, cementWall);
		spawnPrefab (1, -2, cementWall);
		spawnPrefab (2, 2, cementWall);
		spawnPrefab (3, 1, cementWall);
		spawnPrefab (-1, 2, cementWall);
		spawnPrefab (-2, 1, cementWall);
		spawnPrefab (-2, 2, cementWall);
		spawnPrefab (-4, 2, cementWall);
		spawnPrefab (2, -2, cementWall);
		spawnPrefab (2, -1, cementWall);
		spawnPrefab (-2, -1, cementWall);
		
		
		// bottom-right maze
		spawnPrefab (14, 0, cementWall);
		spawnPrefab (12, 0, cementWall);
		spawnPrefab (14, 1, cementWall);
		spawnPrefab (12, 1, cementWall);
		spawnPrefab (14, 2, cementWall);
		spawnPrefab (12, 2, cementWall);
		spawnPrefab (4, -2, cementWall);
		spawnPrefab (8, -2, cementWall);
		spawnPrefab (12, -2, cementWall);
		spawnPrefab (14, -2, cementWall);
		
		spawnPrefab (6, -3, cementWall);
		spawnPrefab (12, -3, cementWall);
		spawnPrefab (14, -3, cementWall);
		
		spawnPrefab (6, -4, cementWall);
		spawnPrefab (12, -4, cementWall);
		
		spawnPrefab (15, -5, cementWall);
		
		spawnPrefab (4, -6, cementWall);
		spawnPrefab (10, -6, cementWall);
		
		spawnPrefab (4, -7, cementWall);
		
		spawnPrefab (8, -8, cementWall);
		spawnPrefab (14, -8, cementWall);
		
		spawnPrefab (4, -9, cementWall);
		spawnPrefab (8, -9, cementWall);
		
		spawnPrefab (8, -10, cementWall);
		spawnPrefab (14, -10, cementWall);
		
		spawnPrefab (4, -11, cementWall);
		spawnPrefab (6, -11, cementWall);
		
		spawnPrefab (4, -12, cementWall);
		spawnPrefab (6, -12, cementWall);
		spawnPrefab (10, -12, cementWall);
		spawnPrefab (14, -12, cementWall);
		
		spawnPrefab (4, -13, cementWall);
		
		spawnPrefab (4, -14, cementWall);
		spawnPrefab (10, -14, cementWall);
		spawnPrefab (12, -14, cementWall);
		
		spawnPrefab (4, -15, cementWall);
		spawnPrefab (10, -15, cementWall);
		
		spawnPrefab (4, -16, cementWall);
		spawnPrefab (7, -16, cementWall);
		spawnPrefab (12, -16, cementWall);
		spawnPrefab (14, -16, cementWall);
		
		spawnPrefab (4, -17, cementWall);
		spawnPrefab (10, -17, cementWall);
		spawnPrefab (12, -17, cementWall);
		spawnPrefab (14, -17, cementWall);
		
		spawnPrefab (14, -19, cementWall);
		spawnPrefab (3, -18, cementWall);
		
		for (int x = -15; x <= columns + 1; x++) 
		{ 
			for (int y = -22; y <= rows + 1; y++)
			{	
				if( x == -15 || x == columns + 1 || y == -22 || y == rows + 1){tile = cementWall;}
				else if( x >= 2 && x <= 9 && y == 1){tile = cementWall;}
				else if( x == -1 && y >= 2 && y <= 7){tile = cementWall;}
				else if( y == 7 && x >= -5 && x <= -1){tile = cementWall;}
				else if( x == 9 && y >  1 && y <= 7){tile = cementWall;}
				else if( y == 7 && x >= 9 && x <= 15){tile = cementWall;}
				else if( x == -5 && y >= 7 && y <= 22){tile = cementWall;}
				else if ( x == 2 && y <= -2 && y >= -22){tile = cementWall;}
				else if( y == -2 && x <= -1 && x >= -13 || x == -8 && y <= -3 && y >= -20){tile = cementWall;}
				else if ( y == -7 && x <= -9 && x >= -15){tile = cementWall;}
				else if( x == -5 && y >= 2 && y <= 6){tile = cementWall;}
				
				//BOTTOM RIGHT
				else if (y == 2 && x == 13){tile = cementWall;}
				else if (y == -1 && x >= 4 && x <= 8 || y == -1 && x >= 10 && x <= 12 || y == -1 && x == 14){tile = cementWall;}
				else if (y == -3 && x >= 3 && x <= 4 || y == -3 && x >= 8 && x <= 10){tile = cementWall;}
				else if (y == -5 && x >= 4 && x <= 13){tile = cementWall;}
				else if (y == -7 && x >= 6 && x <= 8 || y == -7 && x >= 10 && x <= 14){ tile = cementWall;}
				else if ( y == -9 && x >= 10 && x <= 14){ tile = cementWall;}
				else if ( y == -10 && x >=4 && x <= 6){ tile = cementWall;}
				else if ( y == -11 && x >= 8 && x <= 13){ tile = cementWall;}
				else if ( y == -13 && x >= 8 && x <= 10 || y == -13 && x >= 12 && x <= 14){ tile = cementWall;}
				else if ( y == -14 && x >= 6 && x <= 8){ tile = cementWall;}
				else if ( y == -15 && x >= 12 && x <= 14){ tile = cementWall;}
				else if ( x == 14 && y >= 3 && y <= 5) { tile = cementWall;}
				else if ( y == -18 && x >= 4 && x <= 7 || y == -18 && x >= 9 && x <= 12){ tile = cementWall;}
				else if ( y == -20 && x >= 4 && x <= 14) { tile = cementWall;}
				
				//BOTTOM LEFT
				else if (y == -4 && x >= -7 && x <= -4 || y == -4 && x >= -2 && x <= 1){tile = woodBox;}
				else if (x == -4 && y <= -6 && y >= -11 || x == -2 && y <= -6 && y >= -11){tile = woodBox;}
				else if (x == -6 && y <= -6 && y >= -11 || x == 0 && y <= -6 && y >= -11){tile = woodBox;}
				
				else if (x == -7 && y <= -13 && y >= -20 || x == -5 && y <= -13 && y >= -20 || x == -3 && y <= -13 && y >= -20){tile = woodBox;}
				else if (x == -1 && y <= -13 && y >= -20 || x == 1 && y <= -13 && y >= -20){tile = woodBox;}
				else if (y == -20 && x >= -5 && x <= 0){tile = woodBox;}
				else if (y == -11 && x >= -3 && x <= 0){tile = woodBox;}
				else if (y == -12 && x >= -13 && x <= -9){tile = cementWall;}
				
				else if (x == 1 && y <= -6 && y >= -11){spawnPrefab(x, y, milkPrefab); tile = floorTile;}
				else if (x == -7 && y <= -6 && y >= -11){spawnPrefab(x, y, milkPrefab); tile = floorTile;}
				
				// TOP LEFT
				else if (y == 7 && x >= -14 && x <= -11 || y == 7 && x >= -9 && x <= -6){tile = cementWall;}
				else if (y == 13 && x >= -14 && x <= -11 || y == 13 && x >= -9 && x <= -6){tile = cementWall;}
				else if (y == 19 && x >= -14 && x <= -11 || y == 19 && x >= -9 && x <= -6){tile = cementWall;}
				else if (y == 2 && x <= -6 && x >= -9 || y == 2 && x <= -11 && x >= -14){tile = woodBox;}
				else if ( x == -9 && y >= 3 && y <= 6 || x == - 11 && y >= 3 && y <= 6){tile = woodBox;}
				
				
				
				// TOP RIGHT
				// horizontal
				else if (y == 11 && x == -4 || y == 11 && x >= -2 && x <= -1){tile = cementWall;}else if (y == 15 && x == -4 || y == 15 && x >= -2 && x <= -1){tile = cementWall;}else if (y == 19 && x == -4 || y == 19 && x >= -2 && x <= -1){tile = cementWall;}else if (y == 23 && x == -4 || y == 23 && x >= -2 && x <= -1){tile = cementWall;}
				else if (y == 11 && x == 0 || y == 11 && x >= 2 && x <= 3){tile = cementWall;}else if (y == 15 && x == 0 || y == 15 && x >= 2 && x <= 3){tile = cementWall;}else if (y == 19 && x == 0 || y == 19 && x >= 2 && x <= 3){tile = cementWall;}else if (y == 23 && x == 0 || y == 23 && x >= 2 && x <= 3){tile = cementWall;}
				else if (y == 11 && x == 4 || y == 11 && x >= 6 && x <= 7){tile = cementWall;}else if (y == 15 && x == 4 || y == 15 && x >= 6 && x <= 7){tile = cementWall;}else if (y == 19 && x == 4 || y == 19 && x >= 6 && x <= 7){tile = cementWall;}else if (y == 23 && x == 4 || y == 23 && x >= 6 && x <= 7){tile = cementWall;}
				else if (y == 11 && x == 8 || y == 11 && x >= 10 && x <= 11){tile = cementWall;}else if (y == 15 && x == 8 || y == 15 && x >= 10 && x <= 11){tile = cementWall;}else if (y == 19 && x == 8 || y == 19 && x >= 10 && x <= 11){tile = cementWall;}else if (y == 23 && x == 8 || y == 23 && x >= 10 && x <= 11){tile = cementWall;}
				else if (y == 11 && x == 12 || y == 11 && x >= 14 && x <= 15){tile = cementWall;}else if (y == 15 && x == 12 || y == 15 && x >= 14 && x <= 15){tile = cementWall;}else if (y == 19 && x == 12 || y == 19 && x >= 14 && x <= 15){tile = cementWall;}else if (y == 23 && x == 12 || y == 23 && x >= 14 && x <= 15){tile = cementWall;}
				else if (y == 7 && x >= -4 && x <= 4 || y == 7 && x >= 6 && x <= 15){tile = cementWall;}
				//vertical
				else if (x == -1 && y == 22 || x == -1 && y == 8 || x == -1 && y >= 10 && y <= 12 || x == -1 && y >= 14 && y <= 16 || x == -1 && y >= 18 && y <= 20){tile = cementWall;}
				else if (x == 3 && y == 22 || x == 3 && y == 8 || x == 3 && y >= 10 && y <= 12 || x == 3 && y >= 14 && y <= 16 || x == 3 && y >= 18 && y <= 20){tile = cementWall;}
				else if (x == 7 && y == 22 || x == 7 && y == 8 || x == 7 && y >= 10 && y <= 12 || x == 7 && y >= 14 && y <= 16 || x == 7 && y >= 18 && y <= 20){tile = cementWall;}
				else if (x == 11 && y == 22 || x == 11 && y == 8 || x == 11 && y >= 10 && y <= 12 || x == 11 && y >= 14 && y <= 16 || x == 11 && y >= 18 && y <= 20){tile = cementWall;}
				else if (x == 15 && y >= 8 && y <= 22){tile = cementWall;}
				
				
				else{
					tile = floorTile; 
				}
				spawnPrefab (x, y, tile);
				
			}
		}
	}
	
	// Method to add items into the map using parent spawnItem method
	void setupItems(){
		spawnPrefab (11, 4, whiteKeyPrefab);		//1WK
		spawnPrefab (14, 6, goldKeyPrefab);		//1GK
		spawnPrefab (-12, -16, redKeyPrefab);	//1RK
		spawnPrefab (-10, 10, whiteKeyPrefab);
		spawnPrefab (-11, -10, blueKeyPrefab);
		spawnPrefab (-3, 5, goldKeyPrefab);	
		spawnPrefab (-9, -3, blueKeyPrefab);
		spawnPrefab (-10, 16, redKeyPrefab);
		spawnPrefab (13, 21, blueKeyPrefab);
		spawnPrefab (13, 17, whiteKeyPrefab);
		spawnPrefab (5, 4, whiteKeyPrefab);
		
		spawnPrefab (-10, 7, blueGatePrefab);
		spawnPrefab (-10, 13, blueGatePrefab);
		spawnPrefab (-10, 19, blueGatePrefab);
		spawnPrefab (10, 0, whiteGatePrefab);	//1W
		spawnPrefab (0, -2, goldGatePrefab);	//1G
		spawnPrefab (0, 2, whiteGatePrefab);	//2W
		spawnPrefab (-2, 0, redGatePrefab);		//1R
		spawnPrefab (-14, -12, goldGatePrefab);	//2G
		spawnPrefab (-3, 2, redGatePrefab);		//2R
		spawnPrefab (5, 7, whiteGatePrefab);
		spawnPrefab (5, 11, whiteGatePrefab);
		
		
		
		spawnPrefab (1, 1, spiderWeb);
		spawnPrefab (1, -1, spiderWeb);
		spawnPrefab (-1, 1, spiderWeb);
		spawnPrefab (-1, -1, spiderWeb);
		spawnPrefab (-10, 21, portalPrefab);
		
		// BOTTOM RIGHT MAZE
		spawnPrefab (14, -18, woodBox);
		spawnPrefab (5, -9, woodBox);
		spawnPrefab (6, -9, woodBox);
		spawnPrefab (6, -16, woodBox);
		spawnPrefab (7, -16, woodBox);
		spawnPrefab (8, -16, woodBox);
		spawnPrefab (13, -8, woodBox);
		spawnPrefab (13, -10, woodBox);
		
		spawnPrefab (3, -9, trapTile);
		spawnPrefab (3, -14, trapTile);
		spawnPrefab (3, -15, trapTile);
		spawnPrefab (3, -16, trapTile);
		spawnPrefab (7, -19, trapTile);
		spawnPrefab (9, -19, trapTile);
		spawnPrefab (10, -8, trapTile);
		spawnPrefab (10, -10, trapTile);
		spawnPrefab (10, -16, trapTile);
		spawnPrefab (13, -4, trapTile);
		spawnPrefab (15, -4, trapTile);
		spawnPrefab (15, 3, trapTile);
		spawnPrefab (15, 4, trapTile);
		spawnPrefab (15, 5, trapTile);
		spawnPrefab (15, 6, trapTile);
		
		spawnPrefab (15, 1, milkPrefab);
		spawnPrefab (15, 0, milkPrefab);
		spawnPrefab (15, -1, milkPrefab);
		spawnPrefab (15, -2, milkPrefab);

		spawnPrefab (13, 1, milkPrefab);
		spawnPrefab (13, 0, milkPrefab);
		spawnPrefab (13, -1, milkPrefab);
		spawnPrefab (13, -2, milkPrefab);
		
		// BOTTOM LEFT MAZE
		spawnPrefab ( -7, -6, woodBox);
		spawnPrefab ( -7, -11, woodBox);
		spawnPrefab ( 1, -6, woodBox);
		spawnPrefab ( 1, -11, woodBox);
		
		spawnPrefab ( -5, -6, trapTile);
		spawnPrefab ( -3, -6, trapTile);
		spawnPrefab ( -1, -6, trapTile);
		spawnPrefab ( -6, -13, trapTile);
		spawnPrefab ( -4, -13, trapTile);
		spawnPrefab ( -2, -13, trapTile);
		spawnPrefab ( 0, -13, trapTile);
		spawnPrefab ( -6, -15, trapTile);
		spawnPrefab ( -4, -15, trapTile);
		spawnPrefab ( -2, -15, trapTile);
		spawnPrefab ( -0, -15, trapTile);
		
		spawnPrefab ( -5, -6, spiderWeb);
		spawnPrefab ( -3, -6, spiderWeb);
		spawnPrefab ( -1, -6, spiderWeb);
		spawnPrefab ( -6, -13, spiderWeb);
		spawnPrefab ( -4, -13, spiderWeb);
		spawnPrefab ( -2, -13, spiderWeb);
		spawnPrefab ( 0, -13, spiderWeb);
		spawnPrefab ( -6, -15, spiderWeb);
		spawnPrefab ( -4, -15, spiderWeb);
		spawnPrefab ( -2, -15, spiderWeb);
		spawnPrefab ( 0, -15, spiderWeb);
		
		spawnPrefab ( -2, -5, milkPrefab);
		spawnPrefab ( -4, -5, milkPrefab);
		
		spawnPrefab ( -7, -12, milkPrefab);
		spawnPrefab ( 1, -12, milkPrefab);
		spawnPrefab (-3, -5, milkPrefab);
		
		spawnPrefab ( -6, -19, milkPrefab);
		spawnPrefab ( -4, -19, milkPrefab);
		spawnPrefab ( -2, -19, milkPrefab);
		spawnPrefab ( -0, -19, milkPrefab);
		
		spawnPrefab (-11, -16, milkPrefab);
		spawnPrefab (-13, -16, milkPrefab);
		spawnPrefab (-12, -15, milkPrefab);
		spawnPrefab (-12, -17, milkPrefab);
		
		// TOP LEFT
		spawnPrefab (-10, -3, milkPrefab);
		spawnPrefab (-9, -4, milkPrefab);
		spawnPrefab (-11, -5, milkPrefab);
		spawnPrefab (-12, -6, milkPrefab);
		spawnPrefab (-13, -6, milkPrefab);
		
		spawnPrefab ( -12, 3, milkPrefab);
		spawnPrefab ( -12, 4, milkPrefab);
		spawnPrefab ( -12, 5, milkPrefab);
		spawnPrefab ( -12, 6, milkPrefab);
		
		spawnPrefab ( -8, 3,  milkPrefab);
		spawnPrefab ( -8, 4,  milkPrefab);
		spawnPrefab ( -8, 5,  milkPrefab);
		spawnPrefab ( -8, 6,  milkPrefab);

		spawnPrefab (-5, 1, milkPrefab);
		spawnPrefab (-6, -1, milkPrefab);
		spawnPrefab (-5, 0, milkPrefab);
		spawnPrefab (-7, 1, milkPrefab);
		
		spawnPrefab ( -13, 3, whiteKeyPrefab);
		spawnPrefab ( -13, 4, whiteKeyPrefab);
		spawnPrefab ( -13, 5, whiteKeyPrefab);
		spawnPrefab ( -13, 6, whiteKeyPrefab);
		
		spawnPrefab ( -7, 3,  whiteKeyPrefab);
		spawnPrefab ( -7, 4,  whiteKeyPrefab);
		spawnPrefab ( -7, 5,  whiteKeyPrefab);
		spawnPrefab ( -7, 6,  whiteKeyPrefab);
		
		// spidermilk traps
		spawnPrefab (-13, -3, trapTile);
		spawnPrefab (-12, -3, trapTile);
		spawnPrefab (-11, -3, trapTile);
		
		spawnPrefab (-14, -4, trapTile);
		spawnPrefab (-13, -4, trapTile);
		spawnPrefab (-12, -4, trapTile);
		spawnPrefab (-11, -4, trapTile);
		spawnPrefab (-10, -4, trapTile);
		
		spawnPrefab (-14, -5, trapTile);
		spawnPrefab (-13, -5, trapTile);
		spawnPrefab (-12, -5, trapTile);
		spawnPrefab (-10, -5, trapTile);
		spawnPrefab (-9, -5, trapTile);
		
		spawnPrefab (-14, -6, trapTile);
		spawnPrefab (-11, -6, trapTile);
		spawnPrefab (-10, -6, trapTile);
		spawnPrefab (-9, -6, trapTile);
		
		spawnPrefab (-14, 12, spiderWeb);
		spawnPrefab (-13, 12, spiderWeb);
		spawnPrefab (-12, 12, spiderWeb);
		spawnPrefab (-14, 11, spiderWeb);
		spawnPrefab (-13, 11, spiderWeb);
		spawnPrefab (-14, 10, spiderWeb);
		
		spawnPrefab (-8, 12, spiderWeb);
		spawnPrefab (-7, 12, spiderWeb);
		spawnPrefab (-6, 12, spiderWeb);
		spawnPrefab (-7, 11, spiderWeb);
		spawnPrefab (-6, 11, spiderWeb);
		spawnPrefab (-6, 10, spiderWeb);
		
		spawnPrefab (-14, 18, spiderWeb);
		spawnPrefab (-13, 18, spiderWeb);
		spawnPrefab (-12, 18, spiderWeb);
		spawnPrefab (-14, 17, spiderWeb);
		spawnPrefab (-13, 17, spiderWeb);
		spawnPrefab (-14, 16, spiderWeb);
		
		spawnPrefab (-8, 18, spiderWeb);
		spawnPrefab (-7, 18, spiderWeb);
		spawnPrefab (-6, 18, spiderWeb);
		spawnPrefab (-7, 17, spiderWeb);
		spawnPrefab (-6, 17, spiderWeb);
		spawnPrefab (-6, 16, spiderWeb);
		
		spawnPrefab (-6, 14, milkPrefab);
		spawnPrefab (-7, 14, milkPrefab);
		spawnPrefab (-13, 14, milkPrefab);
		spawnPrefab (-14, 14, milkPrefab);
		
		spawnPrefab (-6, 8, milkPrefab);
		spawnPrefab (-7, 8, milkPrefab);
		spawnPrefab (-13, 8, milkPrefab);
		spawnPrefab (-14, 8, milkPrefab);
		// TOP RIGHT
		spawnPrefab (3, 9, woodBox);
		spawnPrefab (7, 13, woodBox);
		spawnPrefab (7, 17, woodBox);
		spawnPrefab (5, 19, woodBox);
		spawnPrefab (9, 19, woodBox);
		spawnPrefab (13, 19, woodBox);
		
		spawnPrefab (-3, 9, milkPrefab);
		spawnPrefab (5, 13, milkPrefab);
		spawnPrefab (1, 17, milkPrefab);
		spawnPrefab (9, 13, milkPrefab);
		spawnPrefab (13, 9, milkPrefab);
		
		spawnPrefab (14, 17, milkPrefab);
		spawnPrefab (12, 17, milkPrefab);
		spawnPrefab (14, 21, milkPrefab);
		spawnPrefab (12, 21, milkPrefab);
		spawnPrefab (13, 20, milkPrefab);
		spawnPrefab (13, 22, milkPrefab);
		
		spawnPrefab (5, 15, trapTile);
		spawnPrefab (1, 11, trapTile);	
		spawnPrefab (-3, 11, trapTile);
		spawnPrefab (1, 15, trapTile);	
		spawnPrefab (-3, 15, trapTile);
		spawnPrefab (1, 19, trapTile);	
		spawnPrefab (-3, 19, trapTile);
		spawnPrefab (-1, 13, trapTile);	
		spawnPrefab (-1, 17, trapTile);
		spawnPrefab (3, 13, trapTile);	
		spawnPrefab (3, 17, trapTile);	
		spawnPrefab (9, 11, trapTile);
		spawnPrefab (13, 11, trapTile);
		spawnPrefab (9, 15, trapTile);
		spawnPrefab (13, 15, trapTile);
		spawnPrefab (11, 9, trapTile);
		spawnPrefab (11, 13, trapTile);	
		spawnPrefab (11, 17, trapTile);	
	}
	
}
