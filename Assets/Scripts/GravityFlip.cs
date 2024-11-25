using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    private Rigidbody2D rb; // Reference to the player's Rigidbody2D
    private bool isGravityFlipped = false; // Track whether gravity is flipped

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for the spacebar press to flip gravity
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FlipGravity();
        }
    }

    void FlipGravity()
    {
        // Toggle the gravity direction
        isGravityFlipped = !isGravityFlipped;
        rb.gravityScale = isGravityFlipped ? -1 : 1;

        // Instead of flipping the scale, rotate the player slightly for visual effect
        transform.rotation = Quaternion.Euler(0, 0, isGravityFlipped ? 180 : 0);
    }

}
