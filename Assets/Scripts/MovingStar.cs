using UnityEngine;

public class MovingStar : MonoBehaviour
{
    public float moveSpeed = 2f;

    void Start()
    {
        Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
        GetComponent<Rigidbody2D>().linearVelocity = randomDirection * moveSpeed;

        Destroy(gameObject, 3f); // Destroy after 3 seconds if not collected
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameTimer gameTimer = Object.FindFirstObjectByType<GameTimer>(); // Updated method
            if (gameTimer != null)
            {
                gameTimer.AddStar(); // Notify GameTimer of the collected star
            }

            Destroy(gameObject); // Destroy the star
        }
    }
}
