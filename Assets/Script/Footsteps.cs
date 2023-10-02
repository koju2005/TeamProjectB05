using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource; // Inspector에서 연결
    public AudioClip footstepSound; // Inspector에서 연결

    private Rigidbody rb;
    private bool isWalking = false;
    private bool isJumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        
        float moveSpeed = rb.velocity.magnitude;

        
        if (rb.velocity.y > 0.1f)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (moveSpeed > 0.1f && !isWalking && isJumping)
        {
            
            footstepAudioSource.clip = footstepSound;
            footstepAudioSource.Play();
            isWalking = true;
        }
        else if (moveSpeed <= 0.1f && isWalking)
        {
           
            footstepAudioSource.Stop();
            isWalking = false;
        }
    }
}
