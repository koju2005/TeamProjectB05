using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteSound : MonoBehaviour
{
    public AudioSource biteAudioSource;
    public AudioClip biteSound;


    public void PlayBiteSound()
    {
        biteAudioSource.clip = biteSound;
        biteAudioSource.Play();
    }
}
