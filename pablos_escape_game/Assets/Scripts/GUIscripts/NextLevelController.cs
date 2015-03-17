using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NextLevelController : MonoBehaviour {
	
	private GameObject nextLevelButton;
	
	
	// Use this for initialization
	void Start () {

		GameObject.Find ("NextLevel").GetComponentInChildren<Text>().text = "Level " + PlayerPrefs.GetInt("SavedLevel");
			
	}
	
	// Update is called once per frame
	void Update () {
		//android back button
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}
		
	}

	public void PlayNextLevelButon(){
		Application.LoadLevel ("Game");
		
	}
	
	public void MenuButton(){
		Application.LoadLevel ("MainMenu");
	}

}