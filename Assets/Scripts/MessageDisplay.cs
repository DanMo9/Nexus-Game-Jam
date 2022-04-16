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
    private string indicatorText = "";
    
    public void SetMessage(string message, float duration = 0)
    {
        textMesh.text = message;
        timeLeft = duration == 0 ? defaultDuration : duration;
        isDisplaying = true;
    }

    public void SetObjectIndicator()
    {
        indicatorText = "Press E to interact";
    }

    public void SetPickupIndicator()
    {
        indicatorText = "Press E to pick up";
    }
    
    public void ClearIndicator()
    {
        indicatorText = "";
    }
    
    private void Update()
    {
        if (isDisplaying)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0)
            {
                textMesh.text = "";
                isDisplaying = false;
            }
        }
        else if (textMesh.text != indicatorText)
        {
            textMesh.text = indicatorText;
        }
    }
}
