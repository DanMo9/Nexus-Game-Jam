using System.Collections.Generic;
using UnityEngine;

public class LightWorldSink : InteractableObject
{
    public GameObject water;
    
    public override bool Use(Rat rat)
    {
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.DollHair))
            return false;
        
        water.SetActive(true);
        
        return true;
    }
}