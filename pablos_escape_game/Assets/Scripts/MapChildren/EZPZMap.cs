using UnityEngine;
using System.Collections;

public class EZPZMap : Map {
	
	private int columns = 7;
	private int rows = 3; 
	
	// Main method that sets up the scene with items and tiles
	public void setupScene () {
		setupGrid ();				// call method to setup grid
		setupTiles ();		// generate wall and floor tiles
		setupItems();
	}
	
	
	void setupGrid (){
		mapTransform = new GameObject ("Map").transform;
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
		GameObject tile;
		
		for (int x = -1; x <= columns + 1; x++) 
		{ 
			for (int y = -1; y <= rows + 1; y++)
			{	
				
				if( (x == -1 || x == columns + 1 || y == -1 || y == rows + 1) || (x == 6 && (y == 2 || y == 1))){
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
		spawnPrefab (4, 2, whiteGatePrefab);

		spawnPrefab (3, 3, redGatePrefab);
		spawnPrefab (4, 3, portalPrefab);
		spawnPrefab (5, 3, goldGatePrefab);

		spawnPrefab (6, 0, blueGatePrefab);
		spawnPrefab (0, 3, blueKeyPrefab);
		spawnPrefab (6, 3, whiteKeyPrefab);


		spawnPrefab (0, 3, spiderWeb);
		spawnPrefab (1, 3, spiderWeb);
		spawnPrefab (0, 2, spiderWeb);
		spawnPrefab (7, 0, spiderWeb);
		spawnPrefab (7, 3, spiderWeb);


		


		
	}
}
