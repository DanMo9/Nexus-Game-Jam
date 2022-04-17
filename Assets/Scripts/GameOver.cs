using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public MessageDisplay messageDisplay;
    
    private void Start()
    {
        var mirror = GetComponent<Mirror>();
        mirror.onRatTeleported += () =>
        {
            messageDisplay.SetMessage("You escape! Press ESC to exit", 1000);
        };
    }
}
