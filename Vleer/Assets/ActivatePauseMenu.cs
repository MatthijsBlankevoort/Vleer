using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePauseMenu : MonoBehaviour {
    private PauseScript pause;
    public Canvas canvas;
	// Use this for initialization
	void Start () {
        pause = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseScript>();
	}
	
	// Update is called once per frame
	void Update () {
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
