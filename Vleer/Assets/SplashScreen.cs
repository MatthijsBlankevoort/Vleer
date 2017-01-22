using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour {

    bool lateStart = false;

    void Update()
    {
        if (!lateStart)
        {
            lateStart = true;
            gameObject.GetComponent<WallOutlines>().QuickyDirtySplashScreenBodge();

        }
        if (gameObject.GetComponent<Renderer>().material.color.a <= 0)
            GameControllerBase.gameController.sceneLoader.LoadScene("Main Menu");
    }
}
