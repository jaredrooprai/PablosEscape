using UnityEngine;
using System.Collections;

public class FourStoryMap : Map {
	
	private int columns = 4;
	private int rows = 4;
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}
	
	

	
	//Sets up the floor and the walls
	void setupTiles () {
		GameObject tile;
		
		for (int x = -1; x <= columns + 1; x++) 
		{ 
			for (int y = -1; y <= rows + 1; y++)
			{	
				
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
		spawnPrefab (1, 0, woodBox);
		spawnPrefab (2, 0, blueGatePrefab);

		spawnPrefab (2, 0, portalPrefab);
		spawnPrefab (2, 1, whiteGatePrefab);
		spawnPrefab (4, 0, goldKeyPrefab);
		spawnPrefab (4, 1, whiteGatePrefab);
		spawnPrefab (3, 1, woodBox);

		spawnPrefab (4, 4, blueKeyPrefab);
		spawnPrefab (4, 3, goldGatePrefab);
		spawnPrefab (3, 4, woodBox);
		spawnPrefab (0, 3, whiteKeyPrefab);

		spawnPrefab (0, 3, spiderWeb);

		spawnPrefab (1, 2, trapTile);
		spawnPrefab (2, 2, trapTile);
		spawnPrefab (3, 2, trapTile);
		spawnPrefab (4, 2, trapTile);
		spawnPrefab (3, 0, trapTile);
		spawnPrefab (0, 4, milkPrefab);

		
		
		
		
	}
}
