using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOutlines : MonoBehaviour {
    
    private Coroutine fadeOutCoroutine;

    public float fadeInSeconds;
    public float fadeOutSeconds;
    public float delayForFadeOut;
    private bool fadedIn;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(
            gameObject.GetComponent<Renderer>().material.color.r, 
            gameObject.GetComponent<Renderer>().material.color.g,
            gameObject.GetComponent<Renderer>().material.color.b, 0);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //print("a");
        if (other.gameObject.tag == "PlayerSonar" || other.gameObject.tag == "Sonar" || other.gameObject.tag == "BigSonar")
        {
            if(fadeOutCoroutine != null)
                StopCoroutine(fadeOutCoroutine);
            StartCoroutine(FadeIn());
        }
    }

    private void Update()
    {
        if(fadedIn == false)
            gameObject.GetComponent<Renderer>().material.color = new Color(
                    gameObject.GetComponent<Renderer>().material.color.r,
                    gameObject.GetComponent<Renderer>().material.color.g,
                    gameObject.GetComponent<Renderer>().material.color.b,
                    0);
    }

    IEnumerator FadeIn()
    {
        fadedIn = true;
        while (gameObject.GetComponent<Renderer>().material.color.a < 1)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(
                gameObject.GetComponent<Renderer>().material.color.r, 
                gameObject.GetComponent<Renderer>().material.color.g, 
                gameObject.GetComponent<Renderer>().material.color.b, 
                gameObject.GetComponent<Renderer>().material.color.a + (Time.deltaTime / fadeInSeconds));
            yield return null;
        }

        fadeOutCoroutine = StartCoroutine(FadeOut(delayForFadeOut));
    }

    IEnumerator FadeOut(float delayForFadeOut)
    {
        yield return new WaitForSeconds(delayForFadeOut);
        
        while (gameObject.GetComponent<Renderer>().material.color.a > 0)
        {
            gameObject.GetComponent<Renderer>().material.color = new Color(
                gameObject.GetComponent<Renderer>().material.color.r, 
                gameObject.GetComponent<Renderer>().material.color.g, 
                gameObject.GetComponent<Renderer>().material.color.b, 
                gameObject.GetComponent<Renderer>().material.color.a - (Time.deltaTime / fadeOutSeconds));
            yield return null;
        }

        fadedIn = false;
    }

    public void QuickyDirtySplashScreenBodge()
    {
        StartCoroutine(FadeIn());
    }
}
