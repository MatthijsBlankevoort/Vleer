using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
	
	// Update is called once per frame
	void Update () {
        float vertSpeed = Input.GetAxis("Vertical") * speed;
        float horSpeed = Input.GetAxis("Horizontal") * speed;

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(horSpeed, vertSpeed);

        if(Input.GetKeyDown(KeyCode.L))
        {
            GameControllerBase.gameController.sceneLoader.LoadScene("Main Menu");
        }
	}

}
