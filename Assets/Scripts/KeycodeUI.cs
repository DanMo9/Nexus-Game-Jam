using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeycodeUI : MonoBehaviour
{
    public TMP_InputField input0;
    public TMP_InputField input1;
    public TMP_InputField input2;
    public TMP_InputField input3;
    public string code;
    
    public Button unlockButton;
    public Button exitButton;
    
    public Action OnExit = () => { };
    public Action OnUnlocked = () => { };

    private void Start()
    {
        unlockButton.onClick.AddListener(() =>
        {
            var entered = input0.text + input1.text + input2.text + input3.text;
            if (entered == code)
            {
                OnUnlocked();
                gameObject.SetActive(false);
            }
        });
        
        exitButton.onClick.AddListener(() =>
        {
            OnExit();
            gameObject.SetActive(false);
        });
    }
}
