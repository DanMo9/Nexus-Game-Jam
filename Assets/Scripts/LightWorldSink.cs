using System;
using System.Collections.Generic;
using UnityEngine;

public class LightWorldSink : InteractableObject
{
    public GameObject water;
    
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.DollHair))
            return false;
        
        water.SetActive(true);
        
        return true;
    }
}

public class LightWorldCrackedMirror : InteractableObject
{
    public GameObject mirror;
    public Sprite fixedMirror;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D collider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<PolygonCollider2D>();
    }

    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Glue))
            return false;
        
        spriteRenderer.sprite = fixedMirror;
        collider.enabled = false;
        mirror.SetActive(true);
        
        return true;
    }
}