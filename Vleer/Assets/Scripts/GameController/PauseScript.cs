using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

    public bool isPaused = false;
    private PlayerController playerController;

    void Start()
    {  
        try
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        } catch (UnityException)
        {

        }
    }

	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Joystick1Button7) && !isPaused)
        {
            Pause();
            playerController.pauseInputDelay = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Joystick1Button7) && isPaused)
        {
            Resume();
        }
	}

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
       
        Time.timeScale = 1;
        isPaused = false;
    }
}
