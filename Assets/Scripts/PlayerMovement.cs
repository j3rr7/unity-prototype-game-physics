using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRigidbody;

    [SerializeField]
    private CinemachineFreeLook cameraCinemachine;

    [Space]

    [SerializeField]
    private float _speed = 10f;

    [SerializeField]
    private float _jumpForce = 3.8f;

    [SerializeField]
    private float _maxVelocityChange = 10f;

    // *****************
    // Private Variables
    // *****************
    private InputAction moveAction;
    private InputAction jumpAction;

    private float _speedMoveForward = 0f;

    void Awake()  
    {
        moveAction = FindAnyObjectByType<PlayerInput>().actions.FindAction("Move");
        jumpAction = FindAnyObjectByType<PlayerInput>().actions.FindAction("Jump");
    }

    void Update()
    {
        // always move forward
        playerRigidbody.MovePosition(playerRigidbody.position + Vector3.forward * _speedMoveForward * Time.deltaTime);

        Vector2 moveDelta = moveAction.ReadValue<Vector2>();

        if (moveDelta != Vector2.zero)
        {
            Vector3 movement = new Vector3(moveDelta.x * _speed, 0, moveDelta.y * _speed);

            if (moveDelta.x != 0 && moveDelta.y != 0)
            {
                movement = movement.normalized * _speed;
            }

            float forceMagnitude = Mathf.Clamp(movement.magnitude, 0, _maxVelocityChange);
            movement = movement.normalized * forceMagnitude;

            playerRigidbody.AddForce(movement * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }

        if (jumpAction.triggered)
        {
            playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {

    }
}
