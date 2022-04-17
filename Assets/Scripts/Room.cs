using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public World worldType;

    public void OnRoomEntered()
    {
        if (worldType == World.light)
        {
            Music.instance.PlayLightMusic();
        }
        else
        {
            Music.instance.PlayDarkMusic();
        }
    }
}
