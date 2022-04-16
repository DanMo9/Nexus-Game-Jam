using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public Button button;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    public void SetEquipped()
    {
        outline.enabled = true;
    }

    public void SetUnEquipped()
    {
        outline.enabled = false;
    }
}
