using System.Collections.Generic;

public class DarkWorldSink : InteractableObject
{
    public override bool Use(List<ToolData> toolData = null)
    {
        if (!HasEquipped(toolData, ToolData.ToolType.DollHair))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}