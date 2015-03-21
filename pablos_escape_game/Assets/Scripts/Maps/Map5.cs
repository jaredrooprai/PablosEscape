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
		for (int i = 0; i <= 5; i++) {
			int temp = i%2;
			if (temp != 0)
				i++;
			else {
				for (int y = 1-rows/2; y <= rows/2; y += 12){
					int y2 = y+2;
					for (int x = 6-columns/2; x <= 10-columns/2 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
					for (int x = 18-columns/2; x <= 22-columns/2 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
					for (int x = 30-columns/2; x <= 34-columns/2 ; x++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x, y2, cementWall);
					}
					for (int x = 42-columns/2; x <= 46-columns/2 ; x++) {
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
				for (int x = 1-columns/2; x <= columns/2; x += 12){
					int x2 = x+2;
					for (int y = 6-rows/2; y <= 10-rows/2 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
					for (int y = 18-rows/2; y <= 22-rows/2 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
					for (int y = 30-rows/2; y <= 34-rows/2 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
					for (int y = 42-rows/2; y <= 46-rows/2 ; y++) {
						spawnPrefab(x, y, cementWall);
						spawnPrefab(x2, y, cementWall);
					}
				}
			}
		}
		
		// create top right corner of rooms
		for (int i = 0; i <= 5; i++) {
			int temp = i%2;
			if (temp != 0)
				i++;
			else {
				for (int y = -rows/2 + 5; y <= rows/2; y += 12) {
					for (int n = -columns/2 + 3; n <= columns/2; n += 12) {
						for (int x = n; x <= n + 2; x++) {
							spawnPrefab(x, y, cementWall);
						}
					}
				}
			}
		}
		
		
		
		
		
		
		
		
		
		
		for (int x = -1-columns/2; x <= columns/2 + 1; x++) 
		{ 
			for (int y = -1-rows/2; y <= rows/2 + 1; y++)
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
		spawnPrefab (0, 0, buttonDownPrefab);
		spawnPrefab (3, 0, portalPrefab);
	}
	
}

