using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestinInputSystem : MonoBehaviour
{
    private Rigidbody rb;
    public float jumpForce;
    public float speed;
    private CustomInput customInputs;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        customInputs = new CustomInput();
        customInputs.Player.Enable();

        // enabling the jump mecanism
        customInputs.Player.Jump.performed += Jump;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = customInputs.Player.Movement.ReadValue<Vector2>();
        rb.AddForce(new Vector3(inputVector.x, 0, inputVector.y) * speed, ForceMode.Force);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        Debug.Log(context);
        if (context.performed)
        {
            Debug.Log("Jump" + context.phase);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
