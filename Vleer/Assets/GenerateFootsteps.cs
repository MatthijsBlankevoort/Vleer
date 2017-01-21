using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFootsteps : MonoBehaviour
{
    public GameObject soundWavePrefab;

    private float footStepDelayTimer, defaultFootStepDelayTimer;
    public GameObject leftFoot, rightFoot;

    private Vector3 previousPosition;
    private EnemyFollowing enemyFollowScript;

    private enum Foot { LeftFoot, RightFoot };
    private Foot currentFoot;

    // Used to change enemy sprite and soundwave color after a player sonar collision has occured
    private Color color;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        enemyFollowScript = GetComponent<EnemyFollowing>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        footStepDelayTimer = 0.5f / enemyFollowScript.speed;
        defaultFootStepDelayTimer = footStepDelayTimer;

        currentFoot = (Foot)Random.Range(0, 1);

        switch(Random.Range(0, 3))
        {
            case 0:
                color = PlayerController.redColor;
                break;

            case 1:
                color = PlayerController.greenColor;
                break;

            case 2:
                color = PlayerController.blueColor;
                break;

            case 3:
                color = PlayerController.yellowColor;
                break;
        }
    }

    void Update()
    {
        if (footStepDelayTimer > 0)
        {
            footStepDelayTimer -= Time.deltaTime;
        }
        else
        {
            if (previousPosition != transform.position)
            {
                GenerateFootstep();
                footStepDelayTimer = defaultFootStepDelayTimer;
            }
        }

        previousPosition = transform.position;

        // Debug
        //*
        if (Input.GetKeyDown(KeyCode.Return))
        {
            spriteRenderer.color = color;
        }
        //*/
    }

    void GenerateFootstep()
    {
        GameObject footStep;

        if (currentFoot == Foot.LeftFoot)
        {
            footStep = Instantiate(soundWavePrefab, leftFoot.transform.position, Quaternion.identity);
            currentFoot = Foot.RightFoot;
        }
        else
        {
            footStep = Instantiate(soundWavePrefab, rightFoot.transform.position, Quaternion.identity);
            currentFoot = Foot.LeftFoot;
        }

        if (footStep != null)
        {
            SonarEffect effect = footStep.GetComponent<SonarEffect>();
            effect.growthSpeed = enemyFollowScript.speed;
            effect.fadeSize = 3f / enemyFollowScript.speed;
            effect.fadeTimer = 1f / enemyFollowScript.speed;

            SpriteRenderer soundWaveSprite = footStep.GetComponent<SpriteRenderer>();
            soundWaveSprite.color = spriteRenderer.color;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        // Implement collision with player sonar so the sprite color and sound wave color change to the enemy's actual color

    }
}
