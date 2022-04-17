using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    [HideInInspector]
    public Button button;
    public Image image;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        outline = GetComponentInChildren<Outline>();
        outline.enabled = false;
    }

    public void SetToolSprite(ToolData toolData)
    {
        image.sprite = toolData.sprite;
        image.color = Color.white;

        switch (toolData.type)
        {
            case ToolData.ToolType.Flashlight:
                break;
            case ToolData.ToolType.LightCabinetKey:
                break;
            case ToolData.ToolType.DarkCabinetKey:
                break;
            case ToolData.ToolType.Scissor:
                break;
            case ToolData.ToolType.Thread:
                image.rectTransform.localScale = new Vector3(4, 4, 4);
                break;
            case ToolData.ToolType.Cotton:
                image.rectTransform.localScale = new Vector3(4, 4, 4);
                image.rectTransform.anchoredPosition = new Vector3(10.5f, -41.5f);
                break;
            case ToolData.ToolType.Doll:
                break;
            case ToolData.ToolType.DollHair:
                image.rectTransform.anchoredPosition = new Vector3(-30, -37);
                break;
            case ToolData.ToolType.Glue:
                image.rectTransform.anchoredPosition = new Vector3(25f, -14f);
                break;
            case ToolData.ToolType.Box:
                image.rectTransform.localScale = new Vector3(2, 2, 2);
                break;
            case ToolData.ToolType.Batteries:
                image.rectTransform.localScale = new Vector3(6, 6, 6);
                image.rectTransform.anchoredPosition = new Vector3(20, 70);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
    }
    
    public void SetEquipped()
    {
        outline.enabled = true;
    }

    public void SetUnEquipped()
    {
        outline.enabled = false;
    }
}
