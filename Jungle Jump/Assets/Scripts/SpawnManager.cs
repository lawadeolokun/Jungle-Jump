using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player;
    private float startDelay = 2;
    private float spawnInterval = 2f;
    private float spawnDistance = 5f;

    void Start()
    {
        // Ensure player reference is not null at the start
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned in the SpawnManager.");
            return;
        }

        // Ensure obstaclePrefabs array is not null or empty at the start
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("Obstacle prefabs array is not set or empty.");
            return;
        }

        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

    void Update()
    {
        // Add any additional update logic if necessary
    }

    void SpawnObstacle()
    {
        // Check if player reference is still valid
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing. Stopping obstacle spawning.");
            return;
        }

        // Check if obstaclePrefabs array is still valid
        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogWarning("Obstacle prefabs array is not valid. Stopping obstacle spawning.");
            return;
        }

        // Spawn the obstacle
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        Vector3 spawnPosition = player.position + player.forward * spawnDistance;
        Quaternion spawnRotation = Quaternion.LookRotation(player.position - spawnPosition);
        Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, spawnRotation);
    }
}
