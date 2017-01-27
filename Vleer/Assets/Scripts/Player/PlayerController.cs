using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed;
    public static Color32 redColor = new Color32(255, 0, 0, 255);
    public static Color32 greenColor = new Color32(0, 255, 0, 255);
    public static Color32 blueColor = new Color32(0, 75, 255, 255);
    public static Color32 yellowColor = new Color32(255, 235, 0, 255);
    public enum PlayerColor { Random, Red, Green, Blue, Yellow };
    private PlayerColor color = PlayerColor.Red;
    private SpriteRenderer mySpriteRenderer;
    private PauseScript pause;
    private Rigidbody2D rigidBody;
    public int pauseInputDelay = 0;
    public ScoreScript scoreScript;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        pause = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseScript>();
        rigidBody = this.gameObject.GetComponent<Rigidbody2D>();
        Color = (PlayerColor)Random.Range(1, 5);
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

        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Q))
        {
            Color = PlayerColor.Green;
            //Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.W))
        {
            Color = PlayerColor.Red;
            //Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button2) || Input.GetKeyDown(KeyCode.E))
        {
            Color = PlayerColor.Blue;
            //Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.R))
        {
            Color = PlayerColor.Yellow;
            //Camera.main.GetComponent<ScreenShake>().Shake(0.05f, 0.1f);
        }

        ////Controller controls
        
        transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * movementSpeed * Time.deltaTime));

        //Arrow keys controls for testing
        rigidBody.velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector2(0, movementSpeed * Time.deltaTime));
            //rigidBody.velocity += new Vector2(0, movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector2(0, -movementSpeed * Time.deltaTime));
            //rigidBody.velocity += new Vector2(0, -movementSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-movementSpeed * Time.deltaTime, 0));
            //rigidBody.velocity += new Vector2(-movementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector2(movementSpeed * Time.deltaTime, 0));
           // rigidBody.velocity += new Vector2(movementSpeed * Time.deltaTime, 0);
        }
        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            //rigidBody.velocity = Vector2.zero;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<GenerateFootsteps>().myColor == color)
            {
                scoreScript.score += 10;
                Destroy(other.gameObject);
                scoreScript.enemies.Remove(other.gameObject);
            }
            else
            {
                // TO DO: Move lives here
                scoreScript.lives--;
                Destroy(other.gameObject);
                scoreScript.enemies.Remove(other.gameObject);
            }
        }
    }

    private PlayerColor Color
    {
        get
        {
            return color;
        }

        set
        {
            if (value == PlayerColor.Red)
            {
                color = value;
                mySpriteRenderer.color = redColor;
            }
            else if (value == PlayerColor.Green)
            {
                color = value;
                mySpriteRenderer.color = greenColor;
            }
            else if (value == PlayerColor.Blue)
            {
                color = value;
                mySpriteRenderer.color = blueColor;
            }
            else if (value == PlayerColor.Yellow)
            {
                color = value;
                mySpriteRenderer.color = yellowColor;
            }
        }
    }
}
    