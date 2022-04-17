
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var number = other.gameObject.GetComponent<Number>();
        if (number != null) number.Display();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var number = other.gameObject.GetComponent<Number>();
        if (number != null) number.Hide();
    }

}