using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    public GameObject starPrefab; // Assign the Star prefab here
    public float spawnInterval = 3f; // Spawn a star every 3 seconds

    // Define horizontal and vertical boundaries
    public float minX = -7f; // Adjust this based on your left boundary
    public float maxX = 7f;  // Adjust this based on your right boundary
    public float minY = -4.1273f; // Ground position (from the Ground object)
    public float maxY = 4.3539f;  // Ceiling position (from the Ceiling object)

    void Start()
    {
        // Repeatedly spawn stars
        InvokeRepeating("SpawnStar", 0f, spawnInterval);
    }

    void SpawnStar()
    {
        // Generate a random position within the defined boundaries
        float randomX = Random.Range(minX, maxX); // Horizontal range
        float randomY = Random.Range(minY, maxY); // Vertical range

        // Spawn the star at the calculated position
        Instantiate(starPrefab, new Vector3(randomX, randomY, 0f), Quaternion.identity);
    }
}
