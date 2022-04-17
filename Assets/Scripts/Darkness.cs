using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Darkness : MonoBehaviour
{
    public float minAlpha = .75f;
    public float maxAlpha = 1f;
    public float frequency = 3f;

    private enum Direction
    {
        Up,
        Down
    }

    private class FlickerRenderer
    {
        public Direction direction;
        public SpriteRenderer renderer;
    }
    
    private List<FlickerRenderer> renderers = new List<FlickerRenderer>();
    private bool fading;

    private void Start()
    {
        var spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        foreach (var spriteRenderer in spriteRenderers)
        {
            spriteRenderer.color = new Color(0, 0, 0, Random.Range(minAlpha, maxAlpha));
            var direction = Random.Range(0, 2);
            renderers.Add(new FlickerRenderer { 
                renderer = spriteRenderer, 
                direction = (Direction)direction
            });
        }
    }

    private void Update()
    {
        if (fading) return;
        
        foreach (var spriteRenderer in renderers)
        {
            var color = spriteRenderer.renderer.color;
            var alpha = color.a;
            if (spriteRenderer.direction == Direction.Up && color.a < maxAlpha)
            {
                alpha = color.a + Time.deltaTime/frequency;
            }
            else if (spriteRenderer.direction == Direction.Up && color.a >= maxAlpha)
            {
                spriteRenderer.direction = Direction.Down;
                alpha = color.a - Time.deltaTime/frequency;
            }
            else if (spriteRenderer.direction == Direction.Down && color.a > minAlpha)
            {
                alpha = color.a - Time.deltaTime/frequency;
            }
            else if (spriteRenderer.direction == Direction.Down && color.a <= minAlpha)
            {
                spriteRenderer.direction = Direction.Up;
                alpha = color.a + Time.deltaTime/frequency;
            }
            
            spriteRenderer.renderer.color = new Color(0, 0, 0, alpha);
        }
    }

    public IEnumerator FadeOut()
    {
        fading = true;
        
        var doneFading = false;
        while (!doneFading)
        {
            doneFading = true;
            foreach (var spriteRenderer in renderers)
            {
                var currentAlpha = spriteRenderer.renderer.color.a;
                var newAlpha = currentAlpha - Time.deltaTime/frequency;
                spriteRenderer.renderer.color = new Color(0, 0, 0, newAlpha);

                if (newAlpha > 0)
                {
                    doneFading = false;
                }
            }

            yield return null;
        }
    }
}
