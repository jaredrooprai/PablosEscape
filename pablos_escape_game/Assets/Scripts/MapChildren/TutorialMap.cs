using UnityEngine;
using System.Collections;

public class TutorialMap : Map {

	private int columns = 4;
	private int rows = 9; 
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		mapTransform = new GameObject ("Map").transform;
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
		spawnPrefab (2, 8, whiteKeyPrefab);
		spawnPrefab (4, 1, whiteGatePrefab);
		spawnPrefab (3, 0, woodBox);
		spawnPrefab (4, 0, portalPrefab);
	}
}
