using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTestSpawner : MonoBehaviour
{
    public GameObject sonar;
    public float growthSpeed, fadeSize, fadeTimer;
    private Color color = Color.white;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            color = PlayerController.redColor;
            print("red");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            color = PlayerController.greenColor;
            print("green");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            color = PlayerController.blueColor;
            print("blue");
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            color = PlayerController.yellowColor;
            print("yellow");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            color = Color.white;
            print("white");
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;
            GameObject sonarRing = Instantiate(sonar, spawnPosition, Quaternion.identity) as GameObject;
            SonarEffect effect = sonarRing.GetComponent<SonarEffect>();
            effect.growthSpeed = growthSpeed;
            effect.fadeSize = fadeSize;
            effect.fadeTimer = fadeTimer;

            SpriteRenderer sonarSpriteRenderer = sonarRing.GetComponent<SpriteRenderer>();
            print(color);
            sonarSpriteRenderer.color = new Color(color.r, color.g, color.b, sonarSpriteRenderer.color.a);
            print(sonarSpriteRenderer.color);
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;
            GameObject sonarRing = Instantiate(sonar, spawnPosition, Quaternion.identity) as GameObject;
            SonarEffect effect = sonarRing.GetComponent<SonarEffect>();
            effect.growthSpeed = growthSpeed * 2;
            effect.fadeSize = fadeSize * 2;
            effect.fadeTimer = fadeTimer * 2;

            SpriteRenderer sonarSpriteRenderer = sonarRing.GetComponent<SpriteRenderer>();
            print(color);
            sonarSpriteRenderer.color = new Color(color.r, color.g, color.b, sonarSpriteRenderer.color.a);
            print(sonarSpriteRenderer.color);
        }
    }
}
