using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Speed of player movement
    [SerializeField] private float minX = 0f;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxX = 0f;
    [SerializeField] private float maxY = 0f;
    [SerializeField] private GameObject bombPrefab;

    public GameObject placedBomb;

    private void Update()
    {
        // Get input for horizontal and vertical movement
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        PlayerMovementt(moveHorizontal, moveVertical);
        if (Input.GetKey(KeyCode.Space))
        {
            if (placedBomb == null)
            { placedBomb = Instantiate(bombPrefab, this.transform.position, Quaternion.identity); }
        }
    }

    private void PlayerMovementt(float moveHorizontal, float moveVertical)
    {
        // Calculate movement direction
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f).normalized;

        // Move the player character
        transform.position += movement * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
        float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}