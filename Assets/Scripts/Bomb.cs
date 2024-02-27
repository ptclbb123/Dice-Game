using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionTimer = 2f; // Time before the bomb explodes
    public float blastRadius = 2f; // Blast radius of the bomb
    public GameObject explosionPrefab; // Prefab for explosion visual effect

    private void Start()
    {
        // Start countdown timer for bomb explosion
        Invoke(nameof(Explode), explosionTimer);
    }

    private void Explode()
    {
        // Detect and handle explosion effects on nearby objects or grid tiles
        HandleExplosion();

        // Instantiate explosion visual effect
        //Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        // Remove the bomb GameObject after explosion
        Destroy(gameObject);
    }

    private void HandleExplosion()
    {
        // Detect nearby objects within blast radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, blastRadius);

        if (colliders.Length != 0)
        {
            foreach (Collider2D collider in colliders)
            {
                // Handle the effects of the explosion on each nearby object
                // For example, destroy walls, damage enemies, etc.
                // You can customize this part based on your game's mechanics
                if (collider.CompareTag("Wall"))
                {
                    Destroy(collider.gameObject);
                }
                // Check if the collider is the player
                if (collider.CompareTag("Player"))
                {
                    // Destroy the player if it's within the blast radius
                    Destroy(collider.gameObject);
                }
                else if (collider.CompareTag("Enemy"))
                {
                    Destroy(collider.gameObject); // Example method to damage enemies
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        // Draw a wire sphere to visualize the blast radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, blastRadius);
    }
}