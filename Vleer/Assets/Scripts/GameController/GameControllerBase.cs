using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerBase : MonoBehaviour {

    public static GameControllerBase gameController;
    [HideInInspector]
    public SceneLoader sceneLoader;

	// Use this for initialization
    void Awake()
    {
        // Check if a GameData object already exists
        if (gameController == null) // If none exist
        {
            DontDestroyOnLoad(this.gameObject); // Never destroy this object on scene switch
            gameController = this; // This will be the GameData object
        }
      else if (gameController != this) Destroy(this.gameObject); // If this is not the object, destroy itself
    }

    void Start()
    {
        sceneLoader = this.gameObject.GetComponent<SceneLoader>();
    }
}
