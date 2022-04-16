using System.Collections.Generic;

public class DollHair : InteractableObject
{
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.Scissor))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}