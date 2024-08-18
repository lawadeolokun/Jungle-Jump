using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player; // Reference to the player's transform
    public float spawnDistance = 10f; // Distance in front of the player where obstacles will spawn
    public float spawnInterval = 2f; // Time interval between spawns in seconds
    public float obstacleSpeed = 5f; // Speed at which obstacles move towards the player

    void Start()
    {
        // Start the coroutine to spawn obstacles at regular intervals
        StartCoroutine(SpawnObstacleRoutine());
    }

    IEnumerator SpawnObstacleRoutine()
    {
        while (true) // Infinite loop to keep spawning obstacles
        {
            SpawnObstacle();

            // Wait for the specified interval before spawning the next obstacle
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObstacle()
    {
        if (obstaclePrefabs.Length == 0)
        {
            Debug.LogError("No obstacles available in the obstaclePrefabs array.");
            return;
        }

        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);

        // Calculate spawn position in front of the player
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;

        // Instantiate the selected obstacle at the calculated position
        GameObject obstacle = Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, obstaclePrefabs[obstacleIndex].transform.rotation);

        // Set the obstacle to move towards the player
        ObstacleMovement obstacleMovement = obstacle.GetComponent<ObstacleMovement>();
        if (obstacleMovement != null)
        {
            obstacleMovement.SetSpeed(obstacleSpeed);
            obstacleMovement.SetDirection((player.position - spawnPosition).normalized);
        }
    }
}

