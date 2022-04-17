using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public MessageDisplay messageDisplay;
    public AudioClip cheering;
    
    private void Start()
    {
        var mirror = GetComponent<Mirror>();
        var source = GetComponent<AudioSource>();
        mirror.onRatTeleported += () =>
        {
            source.PlayOneShot(cheering);
            messageDisplay.SetMessage("You escaped! Press ESC to exit", 1000);
        };
    }
}
