using System.Collections;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float followRange = 10f; // Distance at which the enemy starts following
    public float moveSpeed = 2f; // Enemy movement speed
    public float damage = 10f; // Damage dealt to the player
    public float killThreshold = 0.5f; // Height difference to determine if player jumped on the enemy

    private bool isFollowing = false; // Whether the enemy is following the player
    private Rigidbody rb; // Rigidbody for physics interactions

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check the distance between the enemy and the player
        float distance = Vector3.Distance(transform.position, player.position);

        // Start following the player if within range
        isFollowing = distance <= followRange;

        if (isFollowing)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Move towards the player’s position
        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Keep the enemy on the same plane (no vertical movement)
        transform.position += direction * moveSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the enemy collides with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Check if the player is above the enemy
            float playerHeight = collision.contacts[0].point.y - transform.position.y;

            if (playerHeight > killThreshold)
            {
                // Player is above the enemy, destroy the enemy
                Destroy(gameObject);
                Debug.Log("Enemy killed!");
            }
            else
            {
                // Deal damage to the player
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
