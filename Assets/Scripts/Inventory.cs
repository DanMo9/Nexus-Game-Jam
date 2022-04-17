using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
   public List<ToolData> Equipped { get; } = new List<ToolData>();
   public IEnumerable<ToolData> Tools => tools;
   
   public Action<ToolData> OnUnEquipped = t => {};
   public Action<ToolData> OnEquipped = t => {}; 
   
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
                  OnUnEquipped(toolData);
                  button.SetUnEquipped();
               }
               else
               {
                  Equipped.Add(toolData);
                  OnEquipped(toolData);
                  button.SetEquipped();
               }
            }
         });
      }
   }

   public void AddTool(ToolData toolData)
   {
      if (tools.Contains(toolData)) return;
      
      buttons[tools.Count].SetToolSprite(toolData);
      tools.Add(toolData);
   }
}
