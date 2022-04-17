using UnityEngine;

public class Number : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
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