using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileModifier : MonoBehaviour
{
    // Public attributes
    public Sprite[] sprites;
    public float x;
    public float y;
    public bool isActive;

    // Private attributes
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        isActive = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            spriteRenderer.sprite = sprites[1];
        } else
        {
            spriteRenderer.sprite = sprites[0];
        }
    }
}
