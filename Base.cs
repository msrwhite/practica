using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : StaticObject
{
    public Sprite base_normal;
    public Sprite base_destroyed;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetBaseSprite(bool isNormal)
    {
        if (isNormal)
        {
            spriteRenderer.sprite = base_normal;
        }
        else
        {
            spriteRenderer.sprite = base_destroyed;
        }
    }
}
