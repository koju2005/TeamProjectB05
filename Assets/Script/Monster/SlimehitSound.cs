using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimehitSound : MonoBehaviour
{
    public AudioSource hitAudioSource; 
    public AudioClip hitSound; 

    // �̺�Ʈ�� ȣ���� �Լ�
    public void PlayHitSound()
    {
        hitAudioSource.clip = hitSound;
        hitAudioSource.Play();
    }
}
