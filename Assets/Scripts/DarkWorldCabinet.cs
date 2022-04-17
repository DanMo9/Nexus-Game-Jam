using UnityEngine;

public class DarkWorldCabinet : InteractableObject
{
    public GameObject note;
    
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.DarkCabinetKey))
            return false;

        note.SetActive(true);
        
        return true;
    }
}