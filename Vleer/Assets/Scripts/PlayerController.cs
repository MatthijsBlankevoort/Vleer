using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    private Color32 redColor, greenColor, blueColor, yellowColor;
    private SpriteRenderer mySpriteRenderer;
    private PauseScript pause;
    private Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
        redColor = new Color32(255,0,0,255);
        greenColor = new Color32(0,255,0,255);
        blueColor = new Color32(0,0, 210, 255);
        yellowColor = new Color32(255,235,0,255);
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        pause = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseScript>();
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (pause.isPaused)
            return;


        if (Input.GetKey(KeyCode.Joystick1Button0))
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
        rigidBody.velocity = Vector2.zero;
        rigidBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime);



        /*
        //Arrow keys controls for testing
         rigidBody.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {

            rigidBody.velocity += new Vector2(0,  movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {

            rigidBody.velocity += new Vector2(0, -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

            rigidBody.velocity += new Vector2(-movementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {

            rigidBody.velocity += new Vector2(movementSpeed * Time.deltaTime, 0);
        }
        if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            rigidBody.velocity = Vector2.zero;
        }
        */
    }
}
    