
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.U2D;

public class Flashlight : MonoBehaviour
{
    public Inventory inventory;
    public Rat rat;
    private SpriteShapeRenderer spriteShapeRenderer;

    private void Awake()
    {
        spriteShapeRenderer = GetComponent<SpriteShapeRenderer>();
        spriteShapeRenderer.enabled = false;
        inventory.OnEquipped += data =>
        {
            if (data.type == ToolData.ToolType.Flashlight && rat.inventory.Equipped.Any(x => x.type == ToolData.ToolType.Batteries) ||
                data.type == ToolData.ToolType.Batteries && rat.inventory.Equipped.Any(x => x.type == ToolData.ToolType.Flashlight))
            {
                spriteShapeRenderer.enabled = true;
            }
        };  
        
        inventory.OnUnEquipped += data =>
        {
            if (data.type == ToolData.ToolType.Flashlight ||data.type == ToolData.ToolType.Batteries) spriteShapeRenderer.enabled = false;
        };  
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!spriteShapeRenderer.enabled) return;
        
        var number = other.gameObject.GetComponent<Number>();
        if (number != null) number.Display();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!spriteShapeRenderer.enabled) return;

        var number = other.gameObject.GetComponent<Number>();
        if (number != null) number.Hide();
    }

    private void Update()
    {
        transform.position = rat.transform.position;
        transform.rotation = rat.transform.rotation;
    }
}