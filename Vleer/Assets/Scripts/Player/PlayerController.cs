﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public static Color32 redColor = new Color32(255, 0, 0, 255);
    public static Color32 greenColor = new Color32(0, 255, 0, 255);
    public static Color32 blueColor = new Color32(0, 0, 210, 255);
    public static Color32 yellowColor = new Color32(255, 235, 0, 255);
    private SpriteRenderer mySpriteRenderer;
    private PauseScript pause;
    private Rigidbody2D rigidBody;
    public int pauseInputDelay = 0;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        pause = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseScript>();
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
	}
	void Update()
    {
        if (pause.isPaused)
        {
            return;
        }
        else if (pauseInputDelay > 0)
        {
            pauseInputDelay--;
            return;
        }
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            mySpriteRenderer.color = greenColor;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            mySpriteRenderer.color = redColor;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            mySpriteRenderer.color = blueColor;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            mySpriteRenderer.color = yellowColor;
        }

        //Controller controls
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime);
    }
}
    