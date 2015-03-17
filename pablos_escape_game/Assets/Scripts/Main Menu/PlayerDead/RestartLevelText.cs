using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RestartLevelText : MonoBehaviour {

	private GameObject levelText;
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("Restart Level").GetComponentInChildren<Text>().text = "Restart Level " + PlayerPrefs.GetInt("SavedLevel");
	
	}
}
