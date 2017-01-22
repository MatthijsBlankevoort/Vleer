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
            Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            mySpriteRenderer.color = redColor;
            Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            mySpriteRenderer.color = blueColor;
            Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            mySpriteRenderer.color = yellowColor;
            Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }

        ////Controller controls
        //rigidBody.velocity = Vector2.zero;
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime));

        //    //Arrow keys controls for testing
        //    rigidBody.velocity = Vector2.zero;

        //    if (Input.GetKey(KeyCode.UpArrow))
        //    {

        //        rigidBody.velocity += new Vector2(0,  movementSpeed * Time.deltaTime);
        //    }
        //    if (Input.GetKey(KeyCode.DownArrow))
        //    {

        //        rigidBody.velocity += new Vector2(0, -movementSpeed * Time.deltaTime);
        //    }
        //    if (Input.GetKey(KeyCode.LeftArrow))
        //    {

        //        rigidBody.velocity += new Vector2(-movementSpeed * Time.deltaTime, 0);
        //    }
        //    if (Input.GetKey(KeyCode.RightArrow))
        //    {

        //        rigidBody.velocity += new Vector2(movementSpeed * Time.deltaTime, 0);
        //    }
        //    if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        //    {
        //        rigidBody.velocity = Vector2.zero;
        //    }
    }
}
    