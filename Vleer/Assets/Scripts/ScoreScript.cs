using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour {

    public int score = 0;
    public int lives = 3;
    public float comboTimerStandard = 2f;
    public float comboChargeStart = 10f;
    public float comboMultiplier = 1.5f;
    public GameObject[] enemies;
    public List<GameObject> enemies;
    public GameObject[] enemiesArray;

    public SpriteRenderer mySpriteRenderer;
    public SpriteRenderer enemySpriteRenderer;

    private float comboTimer;
    private float comboChain = 0;
    private PlayerSonar playerSonar;

	// Use this for initialization
	void Start () {
        mySpriteRenderer = this.GetComponent<SpriteRenderer>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        playerSonar = this.GetComponent<PlayerSonar>();
        enemiesArray = GameObject.FindGameObjectsWithTag("Enemy");
        enemies = new List<GameObject>(enemiesArray);
    }
	
	// Update is called once per frame
	void Update () {
        if(comboTimer > 0)
        {
            comboTimer -= Time.deltaTime;
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        if (lives <= 0)
        {
            if (other.gameObject.GetComponent<SpriteRenderer>().color == mySpriteRenderer.color)
            {
                score++;
                Destroy(other.gameObject);
                if (comboTimer > 0)
                {
                    comboChain++;
                    playerSonar.Charge(comboChargeStart * (comboChain * comboMultiplier));
                    comboTimer = comboTimerStandard;
                }
                else
                {
                    comboTimer = comboTimerStandard;
                    comboChain = 0;
                }
            }
            else
            {
                lives--;
                Destroy(other.gameObject);
                if(comboTimer > 0)
                {
                    comboTimer = 0;
                    comboChain = 0;
                }
            }
            Application.LoadLevel("Game Over");
        }
        else if (enemies.Count <= 0)
        {
            Application.LoadLevel("Victory Screen");
        }

	}
}
