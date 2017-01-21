using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarEffect : MonoBehaviour
{
    [Tooltip("The growth speed of the sonar effect in unity units per second.")]
    public float growthSpeed = 1.0f;
    [Tooltip("The size at which to fade out.")]
    public float fadeSize = 1.0f;
    [Tooltip("The amount of seconds the sonar takes to fully fade away.")]
    public float fadeTimer = 0.5f;
    [Tooltip("The amount of seconds the sonar's light is alive")]
    public float fadeLightTimer = 2f;
    // The alpha the sprite starts off at
    private float startAlpha;
    // The size of the effect
    private float size;
    // The light coming from the sonar
    private Light light;
    // The intensity the light starts at
    private float startLightIntensity;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startAlpha = (byte)spriteRenderer.color.a;
        transform.localScale = Vector2.zero;
        light = gameObject.GetComponent<Light>();
        startLightIntensity = light.intensity;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 8);
    }

    void Update()
    {
        light.range = size * 2.2f;

        if (size < fadeSize)
        {
            size += growthSpeed * Time.deltaTime;
            transform.localScale = new Vector2(size, size);
        }
        else if (spriteRenderer.color.a > 0)
        {
            size += growthSpeed * Time.deltaTime;
            transform.localScale = new Vector2(size, size);

            // Change alpha of ring
            Color newSpriteColor = spriteRenderer.color;
            newSpriteColor.a -= startAlpha / fadeTimer * Time.deltaTime;
            spriteRenderer.color = newSpriteColor;
        }
        else if (light.intensity > 0)
        {
            light.intensity -= startLightIntensity / fadeLightTimer * Time.deltaTime;
            //Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
