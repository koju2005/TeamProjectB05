using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public AudioClip footstepSound;

    private Rigidbody _rb;
    private bool isWalking = false;
    private bool isJumping = false;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        float moveSpeed = _rb.velocity.magnitude;


        if (_rb.velocity.y > 0.1f)
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
