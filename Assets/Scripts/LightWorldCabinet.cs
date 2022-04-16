using System.Collections.Generic;
using UnityEngine;

public class LightWorldCabinet : InteractableObject
{
    public Transform flashLightSpawn;
    public GameObject flashLightPrefab;
    
    public override bool Use(Rat rat)
    {
        
        if (!HasEquipped(rat.inventory.Equipped, ToolData.ToolType.LightCabinetKey))
            return false;
        
        var flashLight = Instantiate(flashLightPrefab);
        flashLight.transform.position = flashLightSpawn.transform.position;
        
        return true;
    }
}