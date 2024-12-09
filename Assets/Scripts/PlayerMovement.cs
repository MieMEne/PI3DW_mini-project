using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20;
    private Vector3 motion;
    private Rigidbody rb;
    public float jumpForce = 5f; // Upward force for jumping
    public string groundTag = "ground"; // Tag for ground objects
    private bool isGrounded = false; // Whether the player is on the ground

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal and vertical movement
        motion = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        rb.velocity = new Vector3(motion.x * speed, rb.velocity.y, motion.z * speed);

        // Handle normal jumping (from ground)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump(jumpForce);
        }
    }

    void Jump(float force)
    {
        rb.velocity = new Vector3(rb.velocity.x, force, rb.velocity.z);
    }

    // Detect collision with ground objects
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true; // Player is on the ground
        }
    }

    // Reset grounded state when leaving ground objects
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = false; // Player left the ground
        }
    }
}
// This code is inspired by chatGPT
