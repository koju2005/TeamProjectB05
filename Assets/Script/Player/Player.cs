using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class Player : MonoBehaviour
{
    [Header("Move")]
    public float Speed;
    private Vector2 curMoveMentInput;
    public float jumpForce;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform Camera;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMoveMentInput.y + transform.right * curMoveMentInput.x;
        dir *= Speed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }
    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        Camera.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMoveMentInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMoveMentInput = Vector2.zero;
        }
    }
    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMoveMentInput *= 2;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMoveMentInput /= 2;
        }
    }
    public void OnWalkInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMoveMentInput /= 2;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMoveMentInput *= 2;
        }
    }
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            if (IsGrounded())
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }
    public void OnCrouchInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _capsuleCollider.height = 0.8f;
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            _capsuleCollider.height = 1.7f;
        }
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
            {
                 new Ray(transform.position + (transform.forward * 0.2f)+(Vector3.up*0.01f),Vector3.down),
                 new Ray(transform.position + (-transform.forward * 0.2f)+(Vector3.up*0.01f),Vector3.down),
                 new Ray(transform.position +(transform.right * 0.2f) +(Vector3.up * 0.01f),Vector3.down),
                 new Ray(transform.position +(-transform.right * 0.2f) +(Vector3.up * 0.01f),Vector3.down),
            };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i],0.1f , groundLayerMask))
            {
                 return true;
            }
         }
        return false;
    }
}