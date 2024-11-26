using UnityEngine;

public class MovingStar : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float minY = -4.1273f; // Ground boundary
    public float maxY = 4.3539f;  // Ceiling boundary
    public float minX = -7f; // Left boundary (optional, adjust to your scene)
    public float maxX = 7f;  // Right boundary (optional, adjust to your scene)

    void Start()
    {
        // Generate a random movement direction
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = randomDirection * moveSpeed;

        // Optional: Destroy the star after 3 seconds if not collected
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        // Check if the star goes out of bounds and destroy it
        if (transform.position.y < minY || transform.position.y > maxY ||
            transform.position.x < minX || transform.position.x > maxX)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Trigger the particle effect
            ParticleSystem particleSystem = GetComponentInChildren<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
            }

            // Notify GameTimer and destroy the star
            GameTimer gameTimer = Object.FindFirstObjectByType<GameTimer>();
            if (gameTimer != null)
            {
                gameTimer.AddStar();
            }

            Destroy(gameObject, 0.5f); // Wait briefly to let the effect play
        }
    }

}
