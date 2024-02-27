using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionTimer = 2f; // Time before the bomb explodes
    public float blastRadius = 2f; // Blast radius of the bomb

    private void Start()
    {
        // Start countdown timer for bomb explosion
        Invoke("Explode", explosionTimer);
    }

    private void Explode()
    {
        // Detect and handle explosion effects on nearby objects or grid tiles
        // Implement logic to destroy walls, damage enemies, etc. within blast radius

        // Remove the bomb GameObject after explosion
        Destroy(gameObject);
    }
}