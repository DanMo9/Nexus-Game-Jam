using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    public Button exitButton;
    public GameObject window;
    public Rat rat;

    private void Start()
    {
        exitButton.onClick.AddListener(()=>
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        });
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            window.SetActive(!window.activeSelf);

            if (window.activeSelf)
            {
                rat.DisableMovement();
            }
            else
            {
                rat.EnableMovement();
            }
        }
    }
}
