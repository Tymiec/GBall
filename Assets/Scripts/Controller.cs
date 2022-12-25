using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 input;
    [SerializeField] private Vector3 groundNormal;

    public float speed = 3f;
    public float jumpHeight = 3f;

    public bool IsGrounded => groundNormal != Vector3.zero;
    public static Controller Singleton;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        Singleton = this;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity += input;
        var reducer = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // remove y velocity
        if(reducer.magnitude > speed)
        {
            reducer.Normalize();
            reducer *= speed;
        }

        if(input == Vector3.zero)
        {
            reducer = Vector3.MoveTowards(reducer, Vector3.zero, 0.2f);
            reducer.x = Mathf.MoveTowards(reducer.x, 0f, 0.1f);
            reducer.z = Mathf.MoveTowards(reducer.z, 0f, 0.1f);
        }


        rb.velocity = new Vector3(reducer.x, rb.velocity.y, reducer.z); // keep y velocity
        input.y = 0f;
        groundNormal = Vector3.zero;
    }

    private void OnCollisionStay(Collision collision)
    {
        evaluateCollision(collision);
    }

    private void evaluateCollision(Collision collision)
    {
        for (var i = 0; i < collision.contactCount; i++)
        {
            var contact = collision.GetContact(i);
            groundNormal += contact.normal;
            groundNormal.Normalize();
            
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
           var val = context.ReadValue<Vector2>();
           input = new Vector3(val.x, 0, val.y);
        }
        
        if (context.canceled)
        {
            input = Vector3.zero;
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded)
        {
            // Debug.Log("Jump");
            input += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight) * (groundNormal + Vector3.up).normalized;

        }
    }
}
