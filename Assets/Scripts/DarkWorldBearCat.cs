using System.Collections.Generic;

public class DarkWorldBearCat : InteractableObject
{
    public override bool Use(List<ToolData> toolData)
    {
        if (!HasEquipped(toolData, ToolData.ToolType.Thread, ToolData.ToolType.Cotton))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}