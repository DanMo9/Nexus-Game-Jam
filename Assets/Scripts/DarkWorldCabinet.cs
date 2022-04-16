using System.Collections.Generic;

public class DarkWorldCabinet : InteractableObject
{
    public override bool Use(List<ToolData> toolData = null)
    {
        if (!HasEquipped(toolData, ToolData.ToolType.DarkCabinetKey))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}