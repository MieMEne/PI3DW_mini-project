using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20;
    private Vector3 motion;
    private Rigidbody rb;
    public float jumpForce = 5f; 
    public string groundTag = "ground"; 
    private bool isGrounded = false; 

    //coyote jump for being able to jump a short amout of time after leaving the ground
    public float coyoteTime = 0.2f; 
    private float coyoteTimer = 0f; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Horizontal and vertical movement
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = new Vector3(motion.x * speed, rb.velocity.y, motion.z * speed);

        // Update coyote timer
        if (!isGrounded)
        {
            coyoteTimer -= Time.deltaTime; // Decrease the timer while in the air
        }

        // Handle jumping
        if (Input.GetButtonDown("Jump") && (isGrounded || coyoteTimer > 0f))
        {
            Jump(jumpForce);
        }
    }

    void Jump(float force)
    {
        rb.velocity = new Vector3(rb.velocity.x, force, rb.velocity.z);
        isGrounded = false;
        coyoteTimer = 0f;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true; 
            coyoteTimer = coyoteTime; 
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
}
// This code is inspired by chatGPT
