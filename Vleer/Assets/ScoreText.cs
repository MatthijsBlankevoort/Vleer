using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour {
    private Text myText;
    public SaveScore scoreScript;
	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        scoreScript = GameObject.FindGameObjectWithTag("Score").GetComponent<SaveScore>();
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = scoreScript.myScore.ToString();
	}
}
