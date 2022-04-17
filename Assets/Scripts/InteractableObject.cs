using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Something that can be interacted with by player. Lives in the world
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    public string hint;
    public bool used;
    public AudioClip onUseSound;
    
    public abstract bool Use(Rat rat);

    protected bool HasEquipped(List<ToolData> equipped, params ToolData.ToolType[] types) 
    {
        foreach (var type in types)
        {
            bool found = false;
            foreach (var toolData in equipped)
            {
                if (toolData.type == type) 
                {
                    found = true;
                    break;
                }
            }
            
            if (!found) return false;
        }
        
        return true;
    }
}