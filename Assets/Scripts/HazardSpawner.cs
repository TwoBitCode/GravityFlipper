using UnityEngine;

public class HazardSpawner : MonoBehaviour
{
    public GameObject[] hazardPrefabs; // Array to hold different hazard prefabs
    public float spawnInterval = 3f; // Time between spawns
    public Vector2 spawnRangeX = new Vector2(-7f, 7f); // Horizontal range
    public Vector2 spawnRangeY = new Vector2(-3f, 3f); // Vertical range

    void Start()
    {
        // Start spawning hazards repeatedly
        InvokeRepeating("SpawnHazard", 1f, spawnInterval);
    }

    void SpawnHazard()
    {
        if (hazardPrefabs.Length == 0) return;

        // Select a random hazard prefab
        GameObject hazardPrefab = hazardPrefabs[Random.Range(0, hazardPrefabs.Length)];

        // Choose a random position within the spawn range
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        // Spawn the hazard
        Instantiate(hazardPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}
