using System.Collections.Generic;

public class LightWorldCabinet : InteractableObject
{
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.LightCabinetKey))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}