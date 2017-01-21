using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesManagement : MonoBehaviour {

    public int maxLives = 3;
    private int curLives;

	void Start () {
        curLives = maxLives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void KillPlayer()
    {
        curLives -= 1;
        if(curLives <= 0)
        {
            GameControllerBase.gameController.sceneLoader.LoadScene("Game Over");
        } else
        {
            GameControllerBase.gameController.sceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
