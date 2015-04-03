using UnityEngine;
using System.Collections;

public class TheFiveFXMap : Map {
	
	private int columns = 8;
	private int rows = 8; 
	
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
				} else if (x == 2 && y == 2) {
					spawnPrefab(x, y, whiteGatePrefab);
					spawnPrefab(x, y, goldKeyPrefab);
					tile = floorTile;
				} else if (x == 0 && y == 6) {
					spawnPrefab(x, y, blueGatePrefab);
					spawnPrefab(x, y, redKeyPrefab);
					tile = floorTile;
				} else if (x == 2 && y == 0) {
					spawnPrefab(x, y, redGatePrefab);
					spawnPrefab(x,y, blueKeyPrefab);
					tile = floorTile;
				} else if (x == 6 && y == 0) {
					spawnPrefab(x, y, blueGatePrefab);
					tile = floorTile;
				} else if (x == 6 && y == 7) {
					spawnPrefab(x, y, blueGatePrefab);
					tile = floorTile;
				} else if (x == 7 && y == 2) {
					spawnPrefab(x, y, blueGatePrefab);
					tile = floorTile;
				} else if (x == 8 && y == 6) {
					spawnPrefab(x, y, redGatePrefab);
					tile = floorTile;
				} else if (( x == 2 || x == 6 || y == 2 || y == 6 )){
					spawnPrefab(x, y, goldGatePrefab);
					tile = floorTile;
				}
				else 		// else spawn floor normal floor tile
					tile = floorTile; 
				
				spawnPrefab (x, y, tile);				
			}
		}
	}
	
	// Method to add items into the map using parent spawnItem method
	void setupItems(){
		spawnPrefab (0, 1, goldKeyPrefab);
		spawnPrefab (1, 1, trapTile);
		spawnPrefab (1, 1, spiderWeb);
		spawnPrefab (1, 5, blueKeyPrefab);
		spawnPrefab (7, 7, trapTile);
		spawnPrefab (7, 8, trapTile);

		spawnPrefab (8, 7, trapTile);
		spawnPrefab (8, 8, whiteKeyPrefab);
		spawnPrefab (4,4, portalPrefab);

		spawnPrefab (4, 8, milkPrefab);
		spawnPrefab (4, 7, milkPrefab);
		spawnPrefab (5, 7, milkPrefab);
		spawnPrefab (5, 8, milkPrefab);




		spawnPrefab (8, 5, blueKeyPrefab);
		spawnPrefab (8, 0, redKeyPrefab);
		spawnPrefab (8, 1, blueKeyPrefab);
		
	}
}
