using System;
using System.Collections.Generic;
using UnityEngine;

public class LightWorldBearCat : InteractableObject
{
    public Transform keySpawn;
    public GameObject keyPrefab;
    public Sprite cutSprite;
    
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Thread, ToolData.ToolType.Cotton))
            return false;

        spriteRenderer.sprite = cutSprite;

        var keyTool = GameObject.Instantiate(keyPrefab);
        keyTool.transform.position = keySpawn.transform.position;

        return true;
    }
}