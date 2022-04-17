using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public static Music instance;
    
    public float fadeIncrement = .2f;
    public AudioSource lightWorld;
    private float lightVolume;
    public AudioSource darkWorld;
    private float darkVolume;

    private Coroutine fadeCoroutine;

    private void Awake()
    {
        lightVolume = lightWorld.volume;
        darkVolume = darkWorld.volume;
        darkWorld.volume = 0;
        instance = this;
    }

    public void PlayLightMusic()
    {
        if (lightWorld.isPlaying && Math.Abs(lightWorld.volume - lightVolume) < 0.01f) return;
        
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(CrossFade(darkWorld, lightWorld, lightVolume));
    }

    public void PlayDarkMusic()
    {
        if (darkWorld.isPlaying && Math.Abs(darkWorld.volume - darkVolume) < 0.01f) return;

        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(CrossFade(lightWorld, darkWorld, darkVolume));
    }
    
    private IEnumerator CrossFade(AudioSource fadeOut, AudioSource fadeIn, float volume)
    {
        var startVolume = fadeOut.volume;
        while (fadeOut.volume != 0)
        {
            fadeOut.volume -= fadeIncrement * Time.deltaTime;
            yield return null;
        }
        
        while (fadeIn.volume < volume)
        {
            fadeIn.volume += fadeIncrement * Time.deltaTime;
            yield return null;
        }
        fadeIn.volume = volume;
        
        fadeCoroutine = null;
    }
}
