using UnityEngine;

public class DollDrawer : InteractableObject
{
    public Sprite cutDollSprite;
    public GameObject Hair;
    
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Scissor))
            return false;

        spriteRenderer.sprite = cutDollSprite;
        Hair.SetActive(true);

        return true;
    }
}