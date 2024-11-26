using System.Collections;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    private Hazard[] hazards; // Array to store all hazards

    public void DisableHazards(float duration)
    {
        // Find all active hazards using the updated method
        hazards = Object.FindObjectsByType<Hazard>(FindObjectsInactive.Exclude, FindObjectsSortMode.None);

        // Disable all hazards
        foreach (Hazard hazard in hazards)
        {
            hazard.gameObject.SetActive(false);
        }

        // Re-enable hazards after the duration
        StartCoroutine(ReenableHazards(duration));
    }

    private IEnumerator ReenableHazards(float duration)
    {
        yield return new WaitForSeconds(duration);

        // Re-enable all hazards
        foreach (Hazard hazard in hazards)
        {
            if (hazard != null) // Check if the hazard still exists
            {
                hazard.gameObject.SetActive(true);
            }
        }

        Debug.Log("Hazards Re-enabled!");
    }
}
