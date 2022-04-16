using UnityEngine;

/// <summary>
/// Something that can be interacted with by player. Lives in the world
/// </summary>
public abstract class InteractableObject : MonoBehaviour
{
    public string hint;

    public abstract bool Use(Tool tool = null);
}