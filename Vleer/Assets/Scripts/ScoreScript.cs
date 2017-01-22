using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public int score = 0;
    public int lives = 3;
    public List<GameObject> enemies;
    public GameObject[] enemiesArray;

    public SpriteRenderer mySpriteRenderer;
    public SpriteRenderer enemySpriteRenderer;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<GameObject>(enemiesArray);
    }
	
	// Update is called once per frame
	void Update () {
        if (lives <= 0)
        {
            Application.LoadLevel("Game Over");
        }
        else if (enemies.Count <= 0)
        {
            Application.LoadLevel("Victory Screen");
        }

	}
}
