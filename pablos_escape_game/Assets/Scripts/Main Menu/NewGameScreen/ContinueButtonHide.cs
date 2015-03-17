using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContinueButtonHide : MonoBehaviour {
	private GameObject ContinueButton;

	// Use this for initialization
	void Start () {
		ContinueButton = GameObject.Find ("Continue");
		if (PlayerPrefs.GetInt ("SavedLevel") == 1 || PlayerPrefs.GetInt ("SavedLevel") ==0) {
			ContinueButton.SetActive (false);
		}
		else{
			ContinueButton.SetActive(true);
			GameObject.Find ("Continue").GetComponentInChildren<Text>().text = "Continue Level " + PlayerPrefs.GetInt("SavedLevel");

		}

	}

	void update(){


	}

}
