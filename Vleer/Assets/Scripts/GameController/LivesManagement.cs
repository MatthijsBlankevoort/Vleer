using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManagement : MonoBehaviour {

    public int maxLives;
    private int curLives;

	void Start () {
        curLives = maxLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Died()
    {
        curLives -= 1;
        if(curLives <= 0)
        {
            GameControllerBase.gameController.sceneLoader.LoadScene("Game Over");
        }
    }
}
