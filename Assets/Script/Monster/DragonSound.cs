using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSound : MonoBehaviour
{
    public AudioSource fireAudioSource; 
    public AudioClip fireSound; 

    
    public void PlayFireSound()
    {
        fireAudioSource.clip = fireSound;
        fireAudioSource.Play();
    }
}
