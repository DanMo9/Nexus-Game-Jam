using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Transform spawnPoint;
    public Mirror pairedMirror;
    public bool isLocked;
    public Action onRatTeleported = ()=> {};
    
    [HideInInspector]
    public Room parentRoom;

    private void Start()
    {
        parentRoom = GetComponentInParent<Room>();
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (pairedMirror == null || isLocked) return;
        
        var mouse = other.transform.GetComponent<Rat>();
        mouse.ChangeWorld(pairedMirror.parentRoom.worldType);
        
        other.transform.position = pairedMirror.spawnPoint.position;
        other.transform.rotation = pairedMirror.spawnPoint.rotation;
        
        Camera.main.transform.position = new Vector3(pairedMirror.parentRoom.transform.position.x, pairedMirror.parentRoom.transform.position.y, Camera.main.transform.position.z);
    }
}
