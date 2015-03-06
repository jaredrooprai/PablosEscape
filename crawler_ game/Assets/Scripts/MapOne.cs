using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class MapOne : Map 
{

	private int rows = 5; 
	private int columns = 5;


	public void setupScene ()
	{
		setupGrid ();
		spawn_wall_floor ();
	}

	void setupGrid () 
	{
		transformIt = new GameObject ("Board").transform;
		mapPositions.Clear ();
		for (int x = -1; x <= columns + 1; x++) 
		{
			for (int y = -1; y <= rows + 1; y++) 
			{
				mapPositions.Add (new Vector3 (x, y, 0f));	//z coord is set to 0f because of 2d grid
			}
		}
	}
	
	void spawn_wall_floor () {

		for (int x = -1; x <= columns + 1; x++) 
		{
			for (int y = -1; y <= rows + 1; y++)
			{	
				GameObject toInsta;

				if ( x == -1 || y == -1 || y == columns + 1 || x == rows + 1 )  
					toInsta = wallTile; 
				else 
					toInsta = floorTile; 
		
				GameObject instance = Instantiate (toInsta, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				instance.transform.SetParent (transformIt);
			}
		}
	}
}

