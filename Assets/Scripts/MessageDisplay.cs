using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MessageDisplay : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float defaultDuration = 4f;
    
    private float timeLeft; 
    private string message;
    private bool isDisplaying;

    public void SetMessage(string message, float duration = 0)
    {
        textMesh.text = message;
        timeLeft = duration == 0 ? defaultDuration : duration;
        isDisplaying = true;
    }

    private void Update()
    {
        if (!isDisplaying) return;
        
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            textMesh.text = "";
            isDisplaying = false;
        }
    }
}
