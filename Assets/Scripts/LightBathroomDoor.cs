using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBathroomDoor : MonoBehaviour
{
    private void Start()
    {
        var mirror = GetComponent<Mirror>();
        mirror.onRatTeleported += () =>
        {
            mirror.pairedMirror.isLocked = false;
        };
    }
}
