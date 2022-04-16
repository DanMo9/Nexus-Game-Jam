using System.Collections.Generic;

public class DarkWorldBearCat : InteractableObject
{
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Thread, ToolData.ToolType.Cotton))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}