using System;
using System.Collections.Generic;

public class LightWorldBedsideTable : InteractableObject
{
    public KeycodeUI keycodeUI;
    private Rat rat;

    private void Start()
    {
        keycodeUI.OnUnlocked += () =>
        {
            used = true;
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