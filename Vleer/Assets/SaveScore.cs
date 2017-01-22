using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour {
    private PlayerController player;
    public int myScore;
    // Use this for initialization
    void Start() {
        DontDestroyOnLoad(gameObject);
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        if (player != null)
        {
            myScore = player.GetComponent<ScoreScript>().score;
        }
        
	}
}
