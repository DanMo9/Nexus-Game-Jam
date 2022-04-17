using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public Rat rat;
    
    private void Start()
    {
        var mirror = GetComponent<Mirror>();
        mirror.onRatTeleported += () =>
        {
            mirror.enabled = false;
            rat.DisableMovement();
        };
    }
}
