public class LightWorldCabinet : InteractableObject
{
    public override bool Use(Tool tool = null)
    {
        if (tool == null || tool.toolData.type == ToolData.ToolType.LightCabinetKey)
            return false;
        
        //OPEN cabinet
        return true;
    }
}