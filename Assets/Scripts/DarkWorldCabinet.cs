public class DarkWorldCabinet : InteractableObject
{
    public override bool Use(ToolData toolData = null)
    {
        if (toolData == null || toolData.type == ToolData.ToolType.DarkCabinetKey)
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}