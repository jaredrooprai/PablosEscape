using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonLevelIndicator : MonoBehaviour {
	

	
	// Update is called once per frame
	void Update () {

		GameObject.Find ("Continue").GetComponentInChildren<Text>().text = "Continue Level " + PlayerPrefs.GetInt("SavedLevel");
		
	}
}
