using UnityEngine;

public class Dresser : InteractableObject
{
    public EdgeCollider2D[] collidersToTurnOff;
    public EdgeCollider2D[] collidersToTurnOn;
    public GameObject box;
    
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Box))
            return false;

        foreach (var collider in collidersToTurnOff)
        {
            collider.enabled = false;
        }
        
        foreach (var collider in collidersToTurnOn)
        {
            collider.enabled = true;
        }
        
        box.SetActive(true);
        
        return true;
    }
}