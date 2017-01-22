using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour {
    private float shakeAmount = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shake(0.05f, 0.1f);
        }
    }

    public void Shake(float amt, float length)
    {
        shakeAmount = amt;

        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", length);
    }

    void DoShake()
    {
        if (shakeAmount > 0)
        {
            transform.localPosition = new Vector3(0, 0, transform.position.z);
            Vector3 camPos = transform.position;

            float offsetX = Random.value * shakeAmount * 2 - shakeAmount;
            float offsetY = Random.value * shakeAmount * 2 - shakeAmount;

            camPos.x += offsetX;
            camPos.y += offsetY;

            transform.position = camPos;
        }
    }

    void StopShake()
    {
        CancelInvoke("DoShake");
        transform.localPosition = new Vector3(0, 0, transform.position.z);
    }
}
