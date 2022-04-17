using System.Collections.Generic;
using UnityEngine;

public class DarkWorldBearCat : InteractableObject
{
    public GameObject fixedGo;
    public Transform keySpawn;
    public GameObject keyPrefab;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D collider;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<PolygonCollider2D>();
        fixedGo.SetActive(false);
    }

    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Thread, ToolData.ToolType.Cotton))
            return false;

        var keyTool = GameObject.Instantiate(keyPrefab);
        keyTool.transform.position = keySpawn.transform.position;
        
        collider.enabled = false;
        spriteRenderer.enabled = false;
        fixedGo.SetActive(true);
        
        return true;
    }
}