using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimehitSound : MonoBehaviour
{
    public AudioSource hitAudioSource; 
    public AudioClip hitSound; 

    // 이벤트로 호출할 함수
    public void PlayHitSound()
    {
        hitAudioSource.clip = hitSound;
        hitAudioSource.Play();
    }
}
