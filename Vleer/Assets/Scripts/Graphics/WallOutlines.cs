using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOutlines : MonoBehaviour {
    
    private Coroutine fadeOutCoroutine;

    public float fadeInSeconds;
    public float fadeOutSeconds;
    public float delayForFadeOut;

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Renderer>().material.color = new Color(
            gameObject.GetComponent<Renderer>().material.color.r, 
            gameObject.GetComponent<Renderer>().material.color.g,
            gameObject.GetComponent<Renderer>().material.color.b, 0);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PlayerSonar" || col.gameObject.tag == "Sonar" || col.gameObject.tag == "BigSonar")
        {
            if(fadeOutCoroutine != null)
                StopCoroutine(fadeOutCoroutine);
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeIn()
    {
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
    }

    public void QuickyDirtySplashScreenBodge()
    {
        StartCoroutine(FadeIn());
    }
}
