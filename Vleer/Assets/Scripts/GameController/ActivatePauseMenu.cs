using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePauseMenu : MonoBehaviour {
    private PauseScript pause;
    private Canvas canvas;
	// Use this for initialization
	void Start () {
        pause = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseScript>();
	}
	
	// Update is called once per frame
	void Update () {

        if (canvas == null)
        {
            if (GameObject.FindWithTag("PauseCanvas") != null)
            {
                canvas = GameObject.FindWithTag("PauseCanvas").GetComponent<Canvas>();
                canvas.gameObject.SetActive(false);
            }
            return;
        }

        if (pause.isPaused)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
	}
}
