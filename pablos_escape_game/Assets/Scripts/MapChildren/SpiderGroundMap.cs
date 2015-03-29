using UnityEngine;
using System.Collections;

public class SpiderGroundMap : Map {
	
	private int columns = 8;
	private int rows = 6; 
	
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
				
				if( x == -1 || x == columns + 1 || y == -1 || y == rows + 1){
					tile = woodBox;
				}
				else {	// else spawn floor normal floor tile
					tile = floorTile; 

					if ( x == 0 && y == 0 ) {
					} else if ( x == columns && y == rows ){
						spawnPrefab (x, y, redGatePrefab);
						spawnPrefab (x, y, portalPrefab);

					} else if ( x == 0 && (y == 1 || y == 2 || y == 3 || y == 4 || y == 5) ){
						spawnPrefab (x, y, milkPrefab);

					} else if ( x == 2 && y == 3 ){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 2 && y == 5 ){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 3 && y == 5 ){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 5 && y == 0 ){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 0 && y == 6){
						spawnPrefab (x, y, redKeyPrefab);
					} else if ( x == 8 && y == 1){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 8 && y == 4){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 7 && y == 0){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 8 && y == 0){
						spawnPrefab (x, y, milkPrefab);
					} else if ( x == 8 && y == 4){
						spawnPrefab (x, y, milkPrefab);
					} else 
						spawnPrefab (x, y, trapTile);

					spawnPrefab (x, y, spiderWeb);	

				}


				spawnPrefab (x, y, tile);	


			}
		}
	}
	
	// Method to add items into the map using parent spawnItem method
	void setupItems(){

	}
}
