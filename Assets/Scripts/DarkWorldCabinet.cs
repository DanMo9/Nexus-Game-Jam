using System.Collections.Generic;

public class DarkWorldCabinet : InteractableObject
{
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.DarkCabinetKey))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}