using UnityEngine;
using System.Collections;

public class NewGame : MonoBehaviour {
	
	
	public void NewGame_button(){
		PlayerPrefs.SetInt("SavedLevel", 1);
		Application.LoadLevel ("Game");

	}
}

