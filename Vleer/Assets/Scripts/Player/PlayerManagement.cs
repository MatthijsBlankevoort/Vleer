using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManagement : MonoBehaviour {

    public int maxHealth = 3;
    private int curHealth;

    void Start()
    {
        maxHealth = curHealth;
    }

    public void Kill()
    {
        Destroy(this.gameObject);
    }

	void OnDestroy()
    {
        SceneManager.LoadSceneAsync("Game Over");
    }
}
