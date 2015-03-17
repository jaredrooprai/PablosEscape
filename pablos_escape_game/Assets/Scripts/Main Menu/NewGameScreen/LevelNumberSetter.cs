using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelNumberSetter : MonoBehaviour {

	private Text levelNumber;
	// Use this for initialization
	void Start () {
		levelNumber = GameObject.Find ("Level Number").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		levelNumber.text = "Level " + PlayerPrefs.GetInt("SavedLevel");

	}
}
