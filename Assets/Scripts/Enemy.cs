using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float bombDropCooldown = 3f;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private Vector2 minPosition;
    [SerializeField] private Vector2 maxPosition;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private bool canDropBomb = true;
    private bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ChooseRandomDirection();
    }

    private void Update()
    {
        if (canMove)
        {
            Move();
        }
        DropBomb();
    }

    private void Move()
    {
        // Move the enemy
        Vector2 newPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);
        rb.MovePosition(newPosition);
        // Check for collision with walls
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            canMove = false;
            ChooseRandomDirection();
        }
    }

    private void ChooseRandomDirection()
    {
        Debug.DrawLine(transform.position, transform.position + (Vector3)moveDirection * 0.5f, Color.black);

        // Choose a random direction for each axis
        float xDir = Random.Range(-1f, 1f);
        float yDir = Random.Range(-1f, 1f);

        // Check for collision with walls and adjust direction accordingly
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position, Vector2.left, 0.5f);
        RaycastHit2D upHit = Physics2D.Raycast(transform.position, Vector2.up, 0.5f);
        RaycastHit2D downHit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);

        // Adjust directions to prevent diagonal movement
        if (rightHit.collider != null || leftHit.collider != null)
        {
            // If collided with a horizontal wall, only move vertically
            xDir = 0f;
        }
        else if (upHit.collider != null || downHit.collider != null)
        {
            // If collided with a vertical wall, only move horizontally
            yDir = 0f;
        }

        moveDirection = new Vector2(xDir, yDir).normalized;
        canMove = true;
    }

    private void DropBomb()
    {
        // Drop bomb randomly with a cooldown and only if no bomb is currently active
        if (canDropBomb)
        {
            Instantiate(bombPrefab, transform.position, Quaternion.identity);
            canDropBomb = false;
            Invoke(nameof(ResetBombCooldown), bombDropCooldown);
        }
    }

    private void ResetBombCooldown()
    {
        canDropBomb = true;
    }
}