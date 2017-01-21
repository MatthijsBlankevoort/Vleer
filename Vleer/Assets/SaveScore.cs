using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveScore : MonoBehaviour {
    public PlayerController player;
    public int myScore;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
        myScore = player.GetComponent<ScoreScript>().score;
	}
}
