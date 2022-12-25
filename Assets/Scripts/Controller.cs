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
    public float jumpHeight = 10f;
    public float pressTime = 0f;
    public float maxPressTime = 1f;

    public double duration;
    
    private double power = 1f;

    public bool IsGrounded => groundNormal != Vector3.zero;
    public static Controller Singleton;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
        Singleton = this;
    }

    
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
        // measure the time between context.started and context.canceled
        if (context.started && IsGrounded)
        {
            pressTime = Time.time;
        }
        if (context.canceled && IsGrounded)
        {
            duration = Time.time - pressTime;
            // power = 1f;
            Debug.Log("Duration: " + duration);
            if (duration < maxPressTime)
            {
                power = duration / maxPressTime;
                Debug.Log("Power: " + power);
            }
            else 
            {
                power = 1f;
                Debug.Log("Power: " + power);
            }
        }
        

        // measure the time between context.started and context.canceled
        if (context.canceled && IsGrounded)
        {
            input += Mathf.Sqrt(-2f * Physics.gravity.y * jumpHeight * (float)power) * (groundNormal + Vector3.up).normalized;

        }
    }
}
