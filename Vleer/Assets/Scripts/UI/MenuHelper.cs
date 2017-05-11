using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHelper : MonoBehaviour {
    public void LoadLevel(string levelName)
    {
        GameObject actualGameController = GameObject.FindGameObjectWithTag("GameController");

        actualGameController.GetComponent<SceneLoader>().LoadScene(levelName);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
