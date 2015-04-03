using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour 
{
	public GameObject gameManager;

	// tells Game Manager to go Ahead
	void Awake ()
	{
		if (GameManager.instance == null)
			Instantiate(gameManager);
	}



}
