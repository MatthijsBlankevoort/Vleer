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
    // The alpha the sprite starts off at
    private float startAlpha;
    // The size of the effect
    private float size;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        startAlpha = (byte)spriteRenderer.color.a;
        transform.localScale = Vector2.zero;
    }

    void Update()
    {
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
        else
        {
            Destroy(gameObject);
        }
    }
}
