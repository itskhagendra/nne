using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    [Header("Player Settings")]
    public float moveSpeed = 5f;
    public float lookSpeed = 2f;
    public float gravity = 98f;

    private float rotationX = 0f;
    private CharacterController characterController;
    public Transform playerCapsule;
    [SerializeField]
    float RotationSensitivity;

    private void Start()
    {
        if (IsLocalPlayer)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;
            characterController = GetComponent<CharacterController>();
        }
    }

    private void Update()
    {
        if (IsLocalPlayer)
        {
            
        HandleMovement();
        HandleMouseLook();
        }
    }

    private void HandleMovement()
    {
        // Handle player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 moveVelocity = transform.TransformDirection(moveDirection) * moveSpeed;

        if(characterController.isGrounded)
        {
            Debug.Log("Character is Grounded");
        }
        else
        {
            moveVelocity.y -= gravity * Time.deltaTime*100f;
            Debug.Log("its not Grounded"+moveVelocity.y);
        }
        characterController.Move(moveVelocity * Time.deltaTime);
    }

    private void HandleMouseLook()
    {
        // Handle player mouse look
        float mouseX = Input.GetAxis("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeed;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        playerCapsule.localRotation = Quaternion.Euler(rotationX*RotationSensitivity, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}
