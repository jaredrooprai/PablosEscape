using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Map2 : Map 
{ 
	private int columns = 15;
	private int rows = 15; 
	
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
		for (int x = 5; x <= 15; x++) 
		{ 
			for (int y = 5; y <= 15; y++)
			{	
				if (x == 5 || x == 15 || y == 5 || y == 15) {
					if ( x==5 && y==11){	
						spawnPrefab (x, y, trapTile);
						spawnPrefab (x, y, spiderWeb);

						spawnPrefab (4, 10, trapTile);
					} else
						spawnPrefab (x, y, woodBox);
				}

			}
		}
	
		spawnPrefab (10, 10, portalPrefab);
		// keys 
		spawnPrefab (8, 2, blueKeyPrefab);
		spawnPrefab (8, 2, spiderWeb);

		spawnPrefab (4, 1, redKeyPrefab);
		spawnPrefab (4, 1, spiderWeb);

		spawnPrefab (2, 2, whiteKeyPrefab);
		spawnPrefab (2, 2, spiderWeb);

		spawnPrefab (2, 6, goldKeyPrefab);
		spawnPrefab (2, 6, spiderWeb);



		// blue locks
		spawnPrefab (10, 14, blueGatePrefab);
		spawnPrefab (7, 13, blueGatePrefab);
		spawnPrefab (9, 13, blueGatePrefab);
		spawnPrefab (12,13, blueGatePrefab);
		spawnPrefab (14,13, blueGatePrefab);
		spawnPrefab (10,7, blueGatePrefab);
		spawnPrefab (10,12, blueGatePrefab);
		spawnPrefab (7,11, blueGatePrefab);
		spawnPrefab (9,11, blueGatePrefab);
		spawnPrefab (12,11, blueGatePrefab);
		spawnPrefab (14,11, blueGatePrefab);
		spawnPrefab (6,10, blueGatePrefab);
		spawnPrefab (10,9, blueGatePrefab);
		spawnPrefab (7,8, blueGatePrefab);
		spawnPrefab (9,8, blueGatePrefab);
		spawnPrefab (12,8, blueGatePrefab);
		spawnPrefab (14,8, blueGatePrefab);
		spawnPrefab (7,6, blueGatePrefab);
		spawnPrefab (9,6, blueGatePrefab);
		spawnPrefab (12,6, blueGatePrefab);
		spawnPrefab (14,6, blueGatePrefab);

		// purple locks
		spawnPrefab (7, 14, redGatePrefab);
		spawnPrefab (9, 14, redGatePrefab);
		spawnPrefab (12, 14, redGatePrefab);
		spawnPrefab (14, 14, redGatePrefab);
		spawnPrefab (7, 12, redGatePrefab);
		spawnPrefab (9, 12, redGatePrefab);
		spawnPrefab (12, 12, redGatePrefab);
		spawnPrefab (14, 12, redGatePrefab);
		spawnPrefab (8, 10, redGatePrefab);
		spawnPrefab (11, 10 , redGatePrefab);
		spawnPrefab (13, 10, redGatePrefab);
		spawnPrefab (7, 9, redGatePrefab);
		spawnPrefab (9,9, redGatePrefab);
		spawnPrefab (12, 9, redGatePrefab);
		spawnPrefab (14, 9, redGatePrefab);
		spawnPrefab (7, 7, redGatePrefab);
		spawnPrefab (9, 7, redGatePrefab);
		spawnPrefab (12, 7, redGatePrefab);
		spawnPrefab (14, 7, redGatePrefab);

		spawnPrefab (6, 14,goldGatePrefab);
		spawnPrefab (8, 14,goldGatePrefab);
		spawnPrefab (11, 14,goldGatePrefab);
		spawnPrefab (13,14,goldGatePrefab);
		spawnPrefab (10,13,goldGatePrefab);
		spawnPrefab (6,12,goldGatePrefab);
		spawnPrefab (8,12,goldGatePrefab);
		spawnPrefab (11,12,goldGatePrefab);
		spawnPrefab (13,12,goldGatePrefab);
		spawnPrefab (10,11,goldGatePrefab);
		spawnPrefab (6,9,goldGatePrefab);
		spawnPrefab (8,9,goldGatePrefab);
		spawnPrefab (11,9,goldGatePrefab);
		spawnPrefab (13,9,goldGatePrefab);
		spawnPrefab (10,8,goldGatePrefab);
		spawnPrefab (6,7,goldGatePrefab);
		spawnPrefab (8,7,goldGatePrefab);
		spawnPrefab (11,7,goldGatePrefab);
		spawnPrefab (13,7,goldGatePrefab);
		spawnPrefab (10,6,goldGatePrefab);

		spawnPrefab (6,13,whiteGatePrefab);
		spawnPrefab (8,13,whiteGatePrefab);
		spawnPrefab (11,13,whiteGatePrefab);
		spawnPrefab (13,13,whiteGatePrefab);
		spawnPrefab (6,11,whiteGatePrefab);
		spawnPrefab (8,11,whiteGatePrefab);
		spawnPrefab (11,11,whiteGatePrefab);
		spawnPrefab (13,11,whiteGatePrefab);
		spawnPrefab (7,10,whiteGatePrefab);
		spawnPrefab (9,10,whiteGatePrefab);
		spawnPrefab (12,10,whiteGatePrefab);
		spawnPrefab (14,10,whiteGatePrefab);
		spawnPrefab (6,8,whiteGatePrefab);
		spawnPrefab (8,8,whiteGatePrefab);
		spawnPrefab (11,8,whiteGatePrefab);
		spawnPrefab (13,8,whiteGatePrefab);
		spawnPrefab (6,6,whiteGatePrefab);
		spawnPrefab (8,6,whiteGatePrefab);
		spawnPrefab (11,6,whiteGatePrefab);
		spawnPrefab (13,6,whiteGatePrefab);


		// keys in lock
		spawnPrefab (9,12, blueKeyPrefab);
		spawnPrefab (10,12, goldKeyPrefab);
		spawnPrefab (7,11, whiteKeyPrefab);

		spawnPrefab (6,10, trapTile);
		spawnPrefab (6,12, trapTile);








	}
	
}

