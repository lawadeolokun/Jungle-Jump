using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerLvl2 : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    public Transform player;
    public float startDelay = 2f;
    public float spawnInterval = 2f;
    public float spawnDistance = 10f;
    public float minX = -10f;
    public float maxX = 10f;
    public float minZ = 50f;
    public float maxZ = 100f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform is not assigned in the SpawnManager.");
            return;
        }

        if (obstaclePrefabs == null || obstaclePrefabs.Length == 0)
        {
            Debug.LogError("Obstacle prefabs array is not set or empty.");
            return;
        }

        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
    }

	void SpawnObstacle()
	{
	    if (player == null || obstaclePrefabs == null || obstaclePrefabs.Length == 0)
	    {
	        Debug.LogWarning("Missing references. Stopping obstacle spawning.");
	        return;
	    }

	    // Ensure that all obstacle prefabs are valid
	    for (int i = 0; i < obstaclePrefabs.Length; i++)
	    {
	        if (obstaclePrefabs[i] == null)
	        {
	            Debug.LogWarning("Obstacle prefab at index " + i + " is null.");
	            return;
	        }
	    }

	    // Generate a random position within the defined range
	    Vector3 potentialPosition = new Vector3(
	        Random.Range(minX, maxX),
	        player.position.y, // Match the player's height
	        Random.Range(minZ, maxZ)
	    );

	    // Ensure the obstacle spawns far enough from the player
	    if (Vector3.Distance(potentialPosition, player.position) < spawnDistance)
	    {
	        potentialPosition.z = player.position.z + spawnDistance;
	    }

	    try
	    {
	        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
	        GameObject obstaclePrefab = obstaclePrefabs[obstacleIndex];

	        if (obstaclePrefab != null)
	        {
	            // Adjust the rotation by 180 degrees on the Y-axis
	            Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);

	            Instantiate(obstaclePrefab, potentialPosition, spawnRotation);
	        }
	        else
	        {
	            Debug.LogError("Attempted to instantiate a null obstacle prefab.");
	        }
	    }
	    catch (MissingReferenceException e)
	    {
	        Debug.LogError("Failed to spawn obstacle due to a missing reference: " + e.Message);
	    }
	}
}
