using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSonar : MonoBehaviour {

    public float growthSpeed = 1.0f;
    public float fadeSize = 1.0f;
    public float fadeTimer = 1.0f;
    public float secondsBetweenSonars = 2.0f;
    public GameObject sonarPrefab;
    public float bigGrowthSpeed = 2.0f;
    public float bigFadeSize = 2.0f;
    public float bigFadeTimer = 2.0f;
    public GameObject bigSonarPrefab;
    public float fullCharge = 100f;
    public bool beginWithFullCharge;

    private float timeFromNextSonar;
    private float charge;

	// Use this for initialization
	void Start () {
        timeFromNextSonar = secondsBetweenSonars;
        if (beginWithFullCharge)
            charge = fullCharge;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        timeFromNextSonar -= Time.deltaTime;

        if (timeFromNextSonar <= 0)
        {
            GameObject spawnedSonar = (GameObject)Instantiate(sonarPrefab, gameObject.transform.localPosition, gameObject.transform.rotation);
            spawnedSonar.transform.parent = transform;

            SonarEffect sonarScript = spawnedSonar.GetComponent<SonarEffect>();
            sonarScript.growthSpeed = this.growthSpeed;
            sonarScript.fadeSize = this.fadeSize;
            sonarScript.fadeTimer = this.fadeTimer;

            timeFromNextSonar = secondsBetweenSonars;
        }

        if (Input.GetAxis("Fire Large Sonar") > 0.1f && charge >= fullCharge)
        {
            charge = 0;
            FireLargeSonar();
        }
	}

    void FireLargeSonar()
    {
        GameObject spawnedSonar = (GameObject)Instantiate(bigSonarPrefab, gameObject.transform.position, gameObject.transform.rotation);

        SonarEffect sonarScript = spawnedSonar.GetComponent<SonarEffect>();
        sonarScript.growthSpeed = bigGrowthSpeed;
        sonarScript.fadeSize = bigFadeSize;
        sonarScript.fadeTimer = bigFadeTimer;
    }

    void Charge (float amount)
    {
        charge += amount;
    }
}
