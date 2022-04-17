using UnityEngine;

public class Number : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Display()
    {
        spriteRenderer.enabled = true;
    }
    
    public void Hide()
    {
        spriteRenderer.enabled = false;
    }
}