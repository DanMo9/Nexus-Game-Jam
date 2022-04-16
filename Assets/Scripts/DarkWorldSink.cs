public class DarkWorldSink : InteractableObject
{
    public override bool Use(ToolData toolData = null)
    {
        if (toolData == null || toolData.type != ToolData.ToolType.DollHair)
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}