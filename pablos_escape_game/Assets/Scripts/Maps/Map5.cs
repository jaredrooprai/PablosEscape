using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Map5 : Map 
{ 
	private int columns = 52;
	private int rows = 52; 
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupGrid ();				// call method to setup grid
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}
	
	
	void setupGrid (){
		mapTransform = new GameObject ("Map").transform;
		mapPositions.Clear ();								// clear the list
		for (int x = -columns/2; x <= columns/2 + 1; x++) 			// adding row items into list
		{
			for (int y = -rows/2; y <= rows/2 + 1; y++) 			// adding column items to list
			{
				mapPositions.Add (new Vector3 (x, y, 0f));	// z coord is set to 0f because of 2d grid
			}
		}
	}
	
	//Sets up the floor and the walls
	void setupTiles () {
		GameObject tile;
		
		// create horizontal hallways
		for (int y = -rows/2 + 1; y <= rows/2; y += 12){			// -rows/2 + 1 to create an offset from the left boarder
			int y2 = y+2;											// the += 12 is taking into account the distance between rooms
			for (int n = -columns/2 + 6; n <= columns/2; n += 12){	// -columns/2 + 6 to create an offset from the bottom boarder
				for (int x = n; x <= n+4; x++) {					// make those parallel walls
					if (x != n + 2) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
				}
			}
		}
				
		
		// create vertical walls
		for (int x = -columns/2 + 1; x <= columns/2; x += 12){			// 
			int x2 = x+2;
			for (int n = -columns/2 + 6; n <= columns/2; n += 12){
				for (int y = n; y <= n+4; y++) {
					if (y != n + 2) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
				}
			}
		}

		
		// create top right corner of rooms
		for (int y = -rows/2 + 5; y <= rows/2 + 1; y += 12) {
			for (int n = -columns/2 + 3; n <= columns/2; n += 12) {
				spawnPrefab(n+2, y-1, cementWall);
				spawnPrefab(n+2, y-2, cementWall);
				for (int x = n; x <= n + 2; x++)
					spawnPrefab(x, y, cementWall);
			}
		}
	


		
		// create bottom right corner of rooms
		for (int y = -rows/2 - 1; y <= rows/2 + 1; y += 12) {
			for (int n = -columns/2 + 3; n <= columns/2; n += 12) {
				spawnPrefab(n + 2, y+1, cementWall);
				spawnPrefab(n + 2, y+2, cementWall);
				for (int x = n; x <= n + 2; x++)
					spawnPrefab(x, y, cementWall);
			}
		}

		// code to create bottom left
		for (int y = -rows/2 - 1; y <= rows/2 + 1; y += 12) {
			for (int n = -columns/2 - 1; n <= columns/2; n += 12) {
				spawnPrefab(n, y+1, cementWall);
				spawnPrefab(n, y+2, cementWall);
				for (int x = n; x <= n+2; x++)
					spawnPrefab(x, y, cementWall);
			}
		}

		//Hello ;D hi :D
		for (int y = -rows/2 + 5; y <= rows/2 + 1; y += 12) {
			for (int n = -columns/2 - 1; n <= columns/2; n += 12) {
				spawnPrefab(n, y-1, cementWall);
				spawnPrefab(n, y-2, cementWall);
				for (int x = n; x <= n+2; x++)
					spawnPrefab(x, y, cementWall);
			}
		}
		
		
		// outer boundaries of map
		for (int x = -columns/2 - 1; x <= columns/2 + 1; x++) 
		{ 
			for (int y = -rows/2 - 1; y <= rows/2 + 1; y++)
			{	
				
				if( x == (-columns/2)-1 || x == columns/2 + 1 || y == (-rows/2)-1 || y == rows/2 + 1){
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

		// create green locked doors
		for (int x = -columns/2 + 1; x <= columns/2; x += 12){			// 
			int x2 = x+2;
			for (int y = -columns/2 + 8; y <= columns/2; y += 12){
					spawnPrefab(x, y, whiteGatePrefab);
					spawnPrefab(x2, y, whiteGatePrefab);
			}
		}


		// create purple locked doors
		for (int y = -rows/2 + 1; y <= rows/2; y += 12){			// 
			int y2 = y+2;
			for (int x = -columns/2 + 8; x <= columns/2; x += 12){
					spawnPrefab(x, y, goldGatePrefab);
					spawnPrefab(x, y2, goldGatePrefab);
			}
		}


		/*
		// create top left corner of rooms
		for (int i = 0; i <= 5; i++) { 		// 5 is for number of rooms in game
			int temp = i%2;
			if (temp != 0)
				i++;
			else {
				for (int y = -rows/2 + 5; y <= rows/2 + 1; y += 12) {
					for (int n = -columns/2 - 1; n <= columns/2; n += 12) {
						spawnPrefab(n, y-1, cementWall);
						spawnPrefab(n, y-2, cementWall);
						for (int x = n; x <= n+2; x++)
							spawnPrefab(x, y, cementWall);
					}
				}
			}
		}
		*/
		
		spawnPrefab(1, 1, spiderWeb);
		spawnPrefab(1, 2, spiderWeb);
		spawnPrefab(2, 1, spiderWeb);
		spawnPrefab(2, 2, spiderWeb);

		spawnPrefab(1, -1, spiderWeb);
		spawnPrefab(1, -2, spiderWeb);
		spawnPrefab(2, -1, spiderWeb);
		spawnPrefab(2, -2, spiderWeb);
		
		spawnPrefab(-1, -1, spiderWeb);
		spawnPrefab(-1, -2, spiderWeb);
		spawnPrefab(-2, -1, spiderWeb);
		spawnPrefab(-2, -2, spiderWeb);
		
		spawnPrefab(-1, 1, spiderWeb);
		spawnPrefab(-1, 2, spiderWeb);
		spawnPrefab(-2, 1, spiderWeb);
		spawnPrefab(-2, 2, spiderWeb);

		spawnPrefab(-2, 2, milkPrefab);
		spawnPrefab(-1, 1, milkPrefab);
		
		spawnPrefab(4, 0, milkPrefab);
		spawnPrefab(8, 0, milkPrefab);
		spawnPrefab(0, -6, milkPrefab);
		spawnPrefab(-4, 0, milkPrefab);
		spawnPrefab(-8, 0, milkPrefab);
		spawnPrefab(0, 6, milkPrefab);
		spawnPrefab(12, 3, milkPrefab);
		spawnPrefab(12, -3, milkPrefab);
		spawnPrefab(19, 2, milkPrefab);
		spawnPrefab(19, 4, milkPrefab);
		spawnPrefab(21, 4, milkPrefab);
		spawnPrefab(24, 7, milkPrefab);
		spawnPrefab(24, 5, milkPrefab);
		spawnPrefab(26, 5, milkPrefab);
		spawnPrefab(26, 7, milkPrefab);
		
		spawnPrefab(3, 0, trapTile);
		spawnPrefab(0, 3, trapTile);
		spawnPrefab(5, 0, trapTile);
		spawnPrefab(0, 5, trapTile);
		spawnPrefab(7, 0, trapTile);
		spawnPrefab(0, 7, trapTile);
		spawnPrefab(9, 0, trapTile);
		spawnPrefab(0, 9, trapTile);
		spawnPrefab(0, -3, trapTile);
		spawnPrefab(-3, 0, trapTile);
		spawnPrefab(-5, 0, trapTile);
		spawnPrefab(0, -5, trapTile);
		spawnPrefab(-7, 0, trapTile);
		spawnPrefab(0, -7, trapTile);
		spawnPrefab(-9, 0, trapTile);
		spawnPrefab(0, -9, trapTile);
		spawnPrefab(6, 12, trapTile);
		spawnPrefab(6, -12, trapTile);
		spawnPrefab(12, 6, trapTile);
		spawnPrefab(12, -6, trapTile);
		spawnPrefab(18, 2, trapTile);
		spawnPrefab(18, 3, trapTile);
		spawnPrefab(19, 3, trapTile);
		spawnPrefab(20, 3, trapTile);
		spawnPrefab(20, 4, trapTile);
		spawnPrefab(20, 5, trapTile);
		spawnPrefab(20, 6, trapTile);
		spawnPrefab(21, 5, trapTile);
		spawnPrefab(21, 6, trapTile);
		spawnPrefab(21, 7, trapTile);
		spawnPrefab(22, 4, trapTile);
		spawnPrefab(22, 5, trapTile);
		spawnPrefab(22, 6, trapTile);
		spawnPrefab(22, 7, trapTile);
		spawnPrefab(22, 8, trapTile);
		spawnPrefab(24, 6, trapTile);
		//spawnPrefab(24, 7, trapTile);
		
		spawnPrefab(0, 10, woodBox);
		spawnPrefab(-10, 0, woodBox);
		spawnPrefab(0, -10, woodBox);
		spawnPrefab(24, 3, woodBox);
		spawnPrefab(12, 4, woodBox);
		spawnPrefab(12, -4, woodBox);
		spawnPrefab(18, -2, woodBox);
		spawnPrefab(21, 0, woodBox);
		
		spawnPrefab(3, 0, blueKeyPrefab);
		spawnPrefab(9, 0, whiteKeyPrefab);
		spawnPrefab(15, 0, goldKeyPrefab);
		spawnPrefab(24, 4, whiteKeyPrefab);
		spawnPrefab(26, 6, goldKeyPrefab);

		spawnPrefab(-columns/2 + 5, columns/2 - 2, blueGatePrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 5, redGatePrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 6, milkPrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 7, milkPrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 8, milkPrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 9, milkPrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 10, milkPrefab);
		spawnPrefab(-columns/2 + 2, columns/2 - 11, redGatePrefab);




		spawnPrefab (0, 0, buttonDownPrefab);
		spawnPrefab (-columns/2, rows/2, portalPrefab);
	}
	
}

