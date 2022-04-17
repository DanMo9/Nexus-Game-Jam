
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Flashlight : MonoBehaviour
{
    public Inventory inventory;
    private SpriteShapeRenderer spriteShapeRenderer;

    private void Awake()
    {
        spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
        spriteShapeRenderer.enabled = false;
        inventory.OnEquipped += data =>
        {
            if (data.type == ToolData.ToolType.Flashlight) spriteShapeRenderer.enabled = true;
        };  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var number = other.gameObject.GetComponent<Number>();
        if (number != null) number.Display();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var number = other.gameObject.GetComponent<Number>();
        if (number != null) number.Hide();
    }

}