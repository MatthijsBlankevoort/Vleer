using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    private float buttonWidth, buttonHeight, LSBoxWidth, LSBoxHeight;
    public GUISkin MainMenuGUISkin;
    public Texture controlImage;
	// Use this for initialization
	void Start () {
        //Size buttons
        buttonWidth = Screen.width / 4;
        buttonHeight = Screen.height / 10;
        //Size of the level select box
        LSBoxHeight = Screen.height / 3;
        LSBoxWidth = Screen.width / 3;

    }
	
	// Update is called once per frame
	void OnGUI () {
        if(GUI.Button(new Rect(30, 30, buttonWidth, buttonHeight), "Start Game"))
        {
            //TODO
            //Load the first level
        }
        if(GUI.Button(new Rect(30, 30 + buttonHeight * 2, buttonWidth, buttonHeight), "Level Select(WIP)"))
        {
            //Box in which buttons are located for the levels
            GUI.Box(new Rect(60 + buttonWidth, 30 + buttonHeight * 2, LSBoxWidth, LSBoxHeight), "TODO: Add buttons to every level you have unlocked ");
            //TODO: Add buttons to the levels. Only unlock them when they have been played before.
        }
        if(GUI.Button(new Rect(30, 30 + buttonHeight * 4, buttonWidth, buttonHeight), "Controls(Need Image of controls)"))
        {
            GUI.DrawTexture(new Rect(60 + buttonWidth, 30, controlImage.width, controlImage.height), controlImage);
        }
        if(GUI.Button(new Rect(30, 30 + buttonHeight * 6, buttonWidth, buttonHeight), "Exit Game"))
        {
            Application.Quit();
        }
    }
}
