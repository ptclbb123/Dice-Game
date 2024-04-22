using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float raycastDistance = 10f; // Adjust the distance of the raycast
    public Text directionText; // Reference to the UI Text component

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        if (horizontalInput != 0 || verticalInput != 0)
        {
            float direction;
            if (verticalInput == 0)
            {
                if (horizontalInput > 0) { direction = 0.5f * Mathf.PI; }
                else if (horizontalInput < 0) { direction = 1.5f * Mathf.PI; }
                else { direction = 0; }
            }
            else { direction = Mathf.Atan(horizontalInput / verticalInput); }
            CastRay(direction);
        }
    }

    private void CastRay(float direction)
    {
        // Convert radians to degrees
        float angleInDegrees = direction * Mathf.Rad2Deg;

        Vector3 rayDirection = new Vector3(Mathf.Sin(direction), 0, Mathf.Cos(direction)).normalized;

        Ray ray = new Ray(transform.position, rayDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            Debug.DrawRay(transform.position, rayDirection * hit.distance, Color.green);
            directionText.text = "Direction: " + angleInDegrees.ToString("F2") + " Degrees";
        }
        else
        {
            Debug.DrawRay(transform.position, rayDirection * raycastDistance, Color.red);
            directionText.text = "Direction: " + angleInDegrees.ToString("F2") + " Degrees";
        }
    }
}