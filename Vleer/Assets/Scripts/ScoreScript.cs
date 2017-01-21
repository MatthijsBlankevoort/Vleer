using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public int score = 0;
    public int lives = 3;
    public GameObject[] enemies;

    public SpriteRenderer mySpriteRenderer;
    public SpriteRenderer enemySpriteRenderer;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().color == mySpriteRenderer.color)
            {
                score++;
                Destroy(other.gameObject);
            }
            else
            {
                lives--;
                Destroy(other.gameObject);
            }
        }
    }
}
