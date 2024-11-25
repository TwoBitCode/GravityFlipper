using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab; // Assign the Star prefab here
    public float spawnInterval = 3f; // Spawn a star every 3 seconds

    void Start()
    {
        InvokeRepeating("SpawnStar", 0f, spawnInterval);
    }

    void SpawnStar()
    {
        // Spawn the star at a random position within the screen bounds
        float randomX = Random.Range(-4f, 4f); // Adjust based on your screen size
        float randomY = Random.Range(-3f, 3f); // Adjust based on your screen size
        Instantiate(starPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}
