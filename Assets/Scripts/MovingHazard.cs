using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    public float speed = 2f; // Speed of the hazard
    public float minY = -3f; // Minimum Y position
    public float maxY = 3f;  // Maximum Y position
    public float leftWallX = -5f; // Position of the left wall
    public float rightWallX = 5f; // Position of the right wall

    void Update()
    {
        // Move the hazard from right to left
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Check if the hazard reaches the left wall
        if (transform.position.x <= leftWallX)
        {
            // Reset the hazard to the right wall
            transform.position = new Vector3(rightWallX, Random.Range(minY, maxY), transform.position.z);
        }
    }
}
