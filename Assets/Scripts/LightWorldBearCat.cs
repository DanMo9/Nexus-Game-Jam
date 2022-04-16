public class LightWorldBearCat : InteractableObject
{
    public override bool Use(ToolData toolData = null)
    {
        if (toolData == null || toolData.type != ToolData.ToolType.Scissor)
            return false;
        
        //TODO OPEN cabinet
        
        return true;
    }
}