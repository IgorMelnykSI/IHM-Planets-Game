using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingDetector : MonoBehaviour
{
    public LayerMask groundLayer; // Define the layer for ground objects
    public float groundCheckDistance = 1f; // Distance from the object's bottom to check for ground
    private bool isFlying;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        IsFlying();
    }

    private void IsFlying()
    {
        // Define the ground check radius
        float groundCheckRadius = 1.5f;

        // Check if there's a collider within the groundCheckDistance from the object's bottom
        bool isGrounded = Physics.CheckSphere(transform.position, groundCheckRadius, groundLayer);

        // If the object is not grounded and its y velocity is greater than a small threshold, consider it flying
        if (!isGrounded && Mathf.Abs(rb.velocity.y) > 1.5f)
        {
            isFlying = true;
        }
        else
        {
            isFlying = false;
        }
    }




    public bool GetIsFlying()
    {
        return isFlying;
    }

    
}

