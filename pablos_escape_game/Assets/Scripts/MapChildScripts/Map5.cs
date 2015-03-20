using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Map5 : Map 
{ 
	private int columns = 55;
	private int rows = 55; 
	
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

		// create horizontal hallways
		for (int i = 0; i <= 5; i++) {
			int temp = i%2;
			if (temp != 0)
				i++;
			else {
				for (int y = 1; y <= rows; y += 12){
					int y2 = y+2;
					for (int x = 6; x <= 10 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
					for (int x = 18; x <= 22 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
					for (int x = 30; x <= 34 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
					for (int x = 42; x <= 46 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
				}
			}
		}
		
		// create vertical walls
		for (int i = 0; i <= 5; i++) {
			int temp = i%2;
			if (temp != 0)
				i++;
			else {
				for (int x = 1; x <= rows; x += 12){
					int x2 = x+2;
					for (int y = 6; y <= 10 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
					for (int y = 18; y <= 22 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
					for (int y = 30; y <= 34 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
					for (int y = 42; y <= 46 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
				}
			}
		}

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

