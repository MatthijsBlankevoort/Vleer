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
        if (enemies.Count <= 0)
        {
            Application.LoadLevel("Victory Screen");
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().color == mySpriteRenderer.color)
            {
                score += 10;
                Destroy(other.gameObject);
                enemies.Remove(other.gameObject);
            }
            else
            {
                lives--;
                Destroy(other.gameObject);
                enemies.Remove(other.gameObject);
            }
        }
    }
}
