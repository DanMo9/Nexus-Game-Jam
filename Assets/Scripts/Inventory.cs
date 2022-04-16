using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public List<ToolData> Equipped { get; } = new List<ToolData>();
   
   [SerializeField]
   private InventoryButton[] buttons;
   private List<ToolData> tools = new List<ToolData>();

   private void Start()
   {
      for (var i = 0; i < buttons.Length; i++)
      {
         var button = buttons[i];
         var buttonIdx = i;
         button.button.onClick.AddListener(() =>
         {
            if (tools.Count >= buttonIdx)
            {
               var toolData = tools[buttonIdx];
               if (Equipped.Contains(toolData))
               {
                  Equipped.Remove(toolData);
                  button.SetUnEquipped();
               }
               else
               {
                  Equipped.Add(toolData);
                  button.SetEquipped();
               }
            }
         });
      }
   }

   public void AddTool(ToolData toolData)
   {
      if (tools.Contains(toolData)) return;
      
      var image = buttons[tools.Count].GetComponentInChildren<Image>();
      image.sprite = toolData.sprite;
      image.color = Color.white;
      
      tools.Add(toolData);
   }

   public void RemoveTool(ToolData toolData)
   {
      if (!tools.Contains(toolData)) return;
      
      var toolIndex = tools.IndexOf(toolData);
      
      var image = buttons[toolIndex].GetComponentInChildren<Image>();
      image.sprite = null;
      image.color = Color.clear;
      
      tools.Remove(toolData);
   }
}
