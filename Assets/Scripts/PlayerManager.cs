using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    [Space]

    [SerializeField]
    private Rigidbody playerRigidbody;

    [SerializeField]
    private CinemachineFreeLook cameraCinemachine;

    // *****************
    // Private Variables
    // *****************
    private InputAction moveAction;
    private InputAction jumpAction;

    private float _speedStrave = 15f;
    private float _speedMoveForward = 10f;
    private float _jumpForce = 3.8f;

    void Awake()
    {
        moveAction = FindAnyObjectByType<PlayerInput>().actions.FindAction("Move");
        jumpAction = FindAnyObjectByType<PlayerInput>().actions.FindAction("Jump");
    }

    void Start()
    {
        
    }

    void Update()
    {
        // SafeGuard to make sure object reference is correct
        if (playerRigidbody == null || cameraCinemachine == null) return;

        // Dynamically move forward
        playerRigidbody.MovePosition(playerRigidbody.position + Vector3.forward * _speedMoveForward * Time.deltaTime);

        // Strave
        Vector2 moveDelta = moveAction.ReadValue<Vector2>();
        /*Debug.Log("Move delta: " + moveDelta);*/

        // Move
        if (moveDelta != Vector2.zero)
        {
            var mov_ = new Vector3(moveDelta.x * _speedStrave, 0, moveDelta.y * _speedStrave);

            // Limit maximum velocity after recieving delta
            mov_ = Vector3.ClampMagnitude(mov_, 15f);

            playerRigidbody.AddForce(mov_ * Time.deltaTime, ForceMode.Impulse);
        }

        // Jump
        if (jumpAction.triggered)
        {
            playerRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }

    public void ApplyDamage(float damage)
    {
        Debug.Log("Applying damage: " + damage);

        health -= damage;
        if (health <= 0)
            health = 0;

        Debug.Log("Current health: " + health);

        // Game Over for Player
        if (health == 0)
        {
            StopInput_Immediately();

            FindObjectOfType<UIManager>().ShowGameOverScreen();

            Debug.Log("Game over");
        }
    }

    public void StopInput_Immediately()
    {
        moveAction.Disable();
        jumpAction.Disable();
        _speedMoveForward = 0f;
    }
}
