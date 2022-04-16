using System.Collections.Generic;

public class DarkWorldSink : InteractableObject
{
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.DollHair))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}