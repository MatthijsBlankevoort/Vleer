using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarTestSpawner : MonoBehaviour
{
    public GameObject sonar;
    public float growthSpeed, fadeSize, fadeTimer;
    private Color color;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPosition.z = 0;
            GameObject sonarRing = Instantiate(sonar, spawnPosition, Quaternion.identity) as GameObject;
            SonarEffect effect = sonarRing.GetComponent<SonarEffect>();
            effect.growthSpeed = growthSpeed;
            effect.fadeSize = fadeSize;
            effect.fadeTimer = fadeTimer;
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
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            color = Color.red;
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            color = Color.green;
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            color = Color.blue;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            color = Color.yellow;
        }
    }
}
