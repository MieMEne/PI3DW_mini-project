using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;

public class pointSystem : MonoBehaviour
{
    private int scoreCount = 0; 
    public TextMeshProUGUI scoreText; 

    public Transform finishLine; 
    public int finishPoints = 10; 
    public int heightMultiplier = 5;

    public Rigidbody rb;
    private bool isLockedToFinishLine = false; // Track if the player is locked to the finish line
    public float glideSpeed = 2f; // Speed at which the player glides down

    private void start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.gameObject.name); // Log the object that was collided with
        if (other.CompareTag("coin")) 
        {
            scoreCount++;
            scoreText.text = "Score: " + scoreCount.ToString(); 
            Debug.Log(scoreCount);
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("finishLine"))
        {
            scoreCount += finishPoints;

            scoreText.text = "Score: " + scoreCount.ToString();
            Debug.Log("Points awarded for finish line hit: " + finishPoints);
            LockPlayerToFinishLine();
            StartCoroutine(GlideDown());
        }
    }

    private void LockPlayerToFinishLine()
    {
        isLockedToFinishLine = true;
        rb.velocity = Vector3.zero; // Stop player movement after collision
    }

    // Coroutine to make the player glide down after locking in (The following code is inspired by chatGPT)
    private IEnumerator GlideDown()
    {
        // Glide effect: slowly apply negative gravity to the player to make them fall down
        while (isLockedToFinishLine)
        {
            rb.velocity = new Vector3(rb.velocity.x, -glideSpeed, rb.velocity.z); // Apply downward movement

            // Optional: Break the loop after a set time or condition (e.g., when a key is pressed)
            if (transform.position.y <= finishLine.position.y) // When the player reaches the finish line's height
            {
                isLockedToFinishLine = false; // Stop gliding after reaching the finish line
            }

            yield return null; // Wait until next frame
        }
    }
}
