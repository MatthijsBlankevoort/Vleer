using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	//Once called will exit the game
    public void ExitApplication()
    {
        Application.Quit();
    }
    //Will start the game at first level
    public void StartGame()
    {
        Debug.Log("TODO Load first level");
    }
    //Will load 
    public void LoadLevel(int indexOfLevel, string nameOfLevel)
    {
        Debug.Log("TODO Need levels to load");
    }
    //Will the main menu once called
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
