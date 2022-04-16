using System.Collections.Generic;

public class LightWorldCabinet : InteractableObject
{
    public override bool Use(List<ToolData> toolData = null)
    {
        if (!HasEquipped(toolData, ToolData.ToolType.LightCabinetKey))
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}