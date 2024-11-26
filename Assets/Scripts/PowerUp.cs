using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float effectDuration = 4f; // Duration for the power-up effect
    public float circleRadius = 0.5f; // Radius of the circular motion
    public float circleSpeed = 2f; // Speed of the circular motion

    private Vector3 startPosition; // To store the initial position

    void Start()
    {
        // Store the starting position to anchor the circular motion
        startPosition = transform.position;
    }

    void Update()
    {
        // Circular motion logic
        float xOffset = Mathf.Cos(Time.time * circleSpeed) * circleRadius;
        float yOffset = Mathf.Sin(Time.time * circleSpeed) * circleRadius;
        transform.position = startPosition + new Vector3(xOffset, yOffset, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Power-Up Collected!");

            // Use the updated method to find the HazardManager
            HazardManager hazardManager = Object.FindFirstObjectByType<HazardManager>();
            if (hazardManager != null)
            {
                hazardManager.DisableHazards(effectDuration);
            }

            // Destroy the power-up
            Destroy(gameObject);
        }
    }
}
