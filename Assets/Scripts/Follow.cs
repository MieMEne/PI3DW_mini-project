using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player; 
    public float followRange = 10f; 
    public float moveSpeed = 2f; 
    public float damage = 10f;
    public float killThreshold = 0.5f;

    private bool isFollowing = false; 
    private Rigidbody rb; 

    private pointSystem pointSystem; 
    public int pointsForKill = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //Enables use of the pointSystem script
        pointSystem = FindObjectOfType<pointSystem>();
    }

    void Update()
    {
        // Check distance between enemy and player
        float distance = Vector3.Distance(transform.position, player.position);

        // Start following player
        isFollowing = distance <= followRange;

        if (isFollowing)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Move towards player position
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Enemy can only move hirizontally
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float playerHeight = collision.contacts[0].point.y - transform.position.y;

            if (playerHeight > killThreshold)
            {
                // Increase score whne killing enemy
                if (pointSystem != null)
                {
                    pointSystem.AddPoints(pointsForKill);
                }
                
                Destroy(gameObject);
                Debug.Log("Enemy killed!");
            }
            else
            {
                // damage the player
                PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    Debug.Log("Player took damage!");
                }
            }
        }
    }
}
// This code is inspired by chatGPT