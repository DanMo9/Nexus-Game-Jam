using System;
using System.Collections.Generic;
using UnityEngine;

public class LightWorldBedsideTable : InteractableObject
{
    public KeycodeUI keycodeUI;
    private Rat rat;
    public GameObject DollDrawer;

    private void Start()
    {
        keycodeUI.OnUnlocked += () =>
        {
            used = true;
            rat.EnableMovement();
            DollDrawer.SetActive(true);
        };
        
        keycodeUI.OnExit += () =>
        {
            rat.EnableMovement();
        };
    }

    public override bool Use(Rat rat)
    {
        this.rat = rat;
        rat.DisableMovement();
        keycodeUI.gameObject.SetActive(true);
        return false;
    }
    
    
    
}