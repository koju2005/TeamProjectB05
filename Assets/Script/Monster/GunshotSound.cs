using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshotSound : MonoBehaviour
{
    public AudioSource gunshotAudioSource; 
    public AudioClip gunshotSound; 

    
    public void PlayGunshotSound()
    {
        gunshotAudioSource.clip = gunshotSound;
        gunshotAudioSource.Play();
    }
}
