using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour {
    private float buttonWidth, buttonHeight, buttonPositionX, buttonPositionY ;
    public GUISkin victoryScreenGUI;
	// Use this for initialization
	void Start () {
        buttonWidth = Screen.width / 4;
        buttonHeight = Screen.height / 10;

        buttonPositionX = Screen.width / 4;
        buttonPositionY = Screen.height * 2 / 3;
        
        
	}
	
	// Update is called once per frame
	void OnGUI () {
        GUI.Label(new Rect(Screen.width / 3, 30, Screen.width / 2, Screen.height / 20), "VICTORY!");
        GUI.Label(new Rect(Screen.width / 3, 30 + Screen.height / 20, Screen.width / 2, Screen.height / 20), "You have defeated the shadow horde!");
        //Button to next level
        if (GUI.Button(new Rect(Screen.width / 6, buttonPositionY, buttonWidth, buttonHeight ), "Go to the next level!"))
        {
            //Load the next level

        }

        if (GUI.Button(new Rect(Screen.width / 6 + buttonPositionX, buttonPositionY, buttonWidth, buttonHeight), "Want to try again?"))
        {
            //Reload the previous level
        }

        //Button to restart level
        if (GUI.Button(new Rect(Screen.width / 6 + buttonPositionX *2, buttonPositionY, buttonWidth, buttonHeight), "Go to the main menu!"))
        {
            //Load the main menu
            SceneManager.LoadScene(0);
        }
        //Button to main menu
    }
}
