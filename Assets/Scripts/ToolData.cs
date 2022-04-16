using UnityEngine;

[CreateAssetMenu(fileName = "New Tool",  menuName =  "Tool")]
public class ToolData : ScriptableObject
{
    public enum ToolType
    {
        Flashlight,
        LightCabinetKey,
        DarkCabinetKey,
        Scissor,
        Thread,
        Cotton,
        Doll,
        DollHair,
        Glue,
        Box
    }
    
    public ToolType type;
    public string description;
    public Sprite sprite;
}