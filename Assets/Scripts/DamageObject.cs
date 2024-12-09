using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public float damageAmount = 10f; 

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damageAmount); 
        }
    }
}