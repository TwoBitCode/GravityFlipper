using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public GameObject powerUpPrefab; // Assign the power-up prefab here
    public float spawnInterval = 10f; // Time between spawns
    public Vector2 spawnRangeX = new Vector2(-7f, 7f);
    public Vector2 spawnRangeY = new Vector2(-3f, 3f);

    void Start()
    {
        InvokeRepeating("SpawnPowerUp", 5f, spawnInterval);
    }

    void SpawnPowerUp()
    {
        // Spawn a power-up at a random position
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomY = Random.Range(spawnRangeY.x, spawnRangeY.y);

        Instantiate(powerUpPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}
