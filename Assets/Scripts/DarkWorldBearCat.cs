public class DarkWorldBearCat : InteractableObject
{
    public override bool Use(ToolData toolData = null)
    {
        if (toolData == null || toolData.type != ToolData.ToolType.Thread)
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}