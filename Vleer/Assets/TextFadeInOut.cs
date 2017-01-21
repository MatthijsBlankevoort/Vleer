using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour {

    private Text myText;

    void Start ()
    {
        myText = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        myText.color = new Color(myText.color.r, myText.color.g, myText.color.b, Mathf.PingPong(Time.time, 1));
	}
}
