using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public ToolData Equipped { get; private set; }
   
   [SerializeField]
   private InventoryButton[] buttons;
   private List<ToolData> tools = new List<ToolData>();

   private void Start()
   {
      for (var i = 0; i < buttons.Length; i++)
      {
         var button = buttons[i];
         button.button.onClick.AddListener(() =>
         {
            if (tools.Count >= i)
            {
               var toolData = tools[i];
               if (toolData.Equals(Equipped))
               {
                  Equipped = null;
                  button.SetUnEquipped();
               }
               else
               {
                  Equipped = toolData;
                  button.SetEquipped();
               }
            }
         });
      }
   }

   public void AddTool(ToolData toolData)
   {
      tools.Add(toolData);
      
      var image = buttons[tools.Count].GetComponent<Image>();
      image.sprite = toolData.sprite;
      image.color = Color.white;
   }

   public void RemoveTool(ToolData toolData)
   {
      var toolIndex = tools.IndexOf(toolData);
      
      var image = buttons[toolIndex].GetComponent<Image>();
      image.sprite = null;
      image.color = Color.clear;
      
      tools.Remove(toolData);
   }
}
