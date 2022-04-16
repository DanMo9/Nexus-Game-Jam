using System;
using System.Collections.Generic;
using UnityEngine;

public class LightWorldBearCat : InteractableObject
{
    public Sprite rippedSprite;
    public ToolData key;
    public Transform keySpawn;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Scissor))
            return false;
        
        spriteRenderer.sprite = rippedSprite;
        
        var keyTool = new GameObject("Key").AddComponent<Tool>();
        keyTool.toolData = key;
        keyTool.transform.position = keySpawn.transform.position;
        
        return true;
    }
}