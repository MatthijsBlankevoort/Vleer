using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    private bool nowLoading = false;

    public void LoadScene (string sceneName)
    {
        if (!nowLoading)
        {
            GameObject loadingText = GameObject.FindWithTag("LoadText");
            if (loadingText != null)
                loadingText.GetComponent<Text>().enabled = true;
            else
            {
                StartCoroutine(LoadInLoadingScreen(sceneName));
                return;
            }

            nowLoading = true;

            StartCoroutine(LoadThisScene(sceneName));
        }
    }

    IEnumerator LoadThisScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone)
        {
            yield return null;
        }

        nowLoading = false;
    }

    IEnumerator LoadInLoadingScreen(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("Loading");

        while (!async.isDone)
        {
            yield return null;
        }
        
        async = SceneManager.LoadSceneAsync(sceneName);

        while (!async.isDone)
        {
            yield return null;
        }

        nowLoading = false;
    }
        
}
