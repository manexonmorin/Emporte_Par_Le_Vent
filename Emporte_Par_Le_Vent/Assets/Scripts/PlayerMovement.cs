using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CustomInput input = null;

    private Vector3 moveVector = Vector3.zero;

    private Rigidbody rb;
    public float moveSpeed;
    private void Awake()
    {
        input = new CustomInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += onMovementPerformed;
        input.Player.Movement.canceled += onMovementCancelled;
    }

    private void OnDisable()
    {
        input?.Disable();
        input.Player.Movement.performed -= onMovementPerformed;
        input.Player.Movement.canceled -= onMovementCancelled;
    }

    private void onMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector3>();
    }

    private void onMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = Vector3.zero;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(moveVector);
        rb.velocity = moveVector.normalized * moveSpeed * Time.deltaTime;
    }
}
