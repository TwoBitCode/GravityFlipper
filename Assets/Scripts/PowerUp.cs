using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float effectDuration = 4f; // Duration for the power-up effect

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
