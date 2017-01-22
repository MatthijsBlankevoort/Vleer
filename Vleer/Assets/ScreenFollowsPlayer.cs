using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFollowsPlayer : MonoBehaviour {
    
    public Transform playerPos;
    public float  followSpeed;
    private float xTarget, yTarget, xNew, yNew;
    private float xMax, yMax, xMin, yMin;
    private Vector2 tarPos; 
    public Transform upperWall, lowerWall, rightWall, leftWall;
	// Use this for initialization
	void Start () {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //Get the boundaries
        xMax = rightWall.transform.position.x;
        xMin = leftWall.transform.position.x;
        yMax = upperWall.transform.position.y;
        yMin = lowerWall.transform.position.y;
    }

    private void Update()
    {
        //Player is within the camera bounds so camera follows normally
        if(playerPos.position.y < yMax && playerPos.position.y > yMin)
        {
            tarPos = new Vector2(playerPos.position.x, playerPos.position.y);
        }
        //When out of y Axis bounds. Freeze the y-Axis
        if (playerPos.position.y > yMax)
        {
            tarPos = new Vector2(playerPos.position.x, yMax);
        }
        else if (playerPos.position.y < yMin)
        {
            tarPos = new Vector2(playerPos.position.x, yMin);
        }

        if (playerPos.position.x > xMax)
        {
            tarPos = new Vector2(xMax, playerPos.position.y);
        }
        else if (playerPos.position.x < xMin)
        {
            tarPos = new Vector2(xMin, playerPos.position.y);
        }

        if (playerPos.position.y > yMax && playerPos.position.x > xMax)
        {
            tarPos = new Vector2(xMax, yMax);
        }

        if (playerPos.position.y > yMax && playerPos.position.x < xMin)
        {
            tarPos = new Vector2(xMin, yMax);
        }

        if (playerPos.position.y < yMin && playerPos.position.x > xMax)
        {
            tarPos = new Vector2(xMax, yMin);
        }

        if (playerPos.position.y < yMin && playerPos.position.x < xMin)
        {
            tarPos = new Vector2(xMin, yMin);
        }

        xNew = Mathf.Lerp(transform.position.x, tarPos.x, Time.deltaTime * followSpeed);
        yNew = Mathf.Lerp(transform.position.y, tarPos.y, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);


    }
    // Update is called once per frame
    void FixedUpdate () {


        //xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        //yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        //transform.position = new Vector3(xNew, yNew, transform.position.z);
    }
}
