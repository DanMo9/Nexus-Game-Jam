using System;
using System.Collections.Generic;
using UnityEngine;

public class LightWorldBearCat : InteractableObject
{
    public Sprite rippedSprite;
    public ToolData key;
    public Transform keySpawn;
    public GameObject keyPrefab;
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
        
        var keyTool = GameObject.Instantiate(keyPrefab);
        keyTool.transform.position = keySpawn.transform.position;
        
        return true;
    }
}