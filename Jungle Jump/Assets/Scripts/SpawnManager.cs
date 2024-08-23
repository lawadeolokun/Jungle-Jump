using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	public GameObject[] obstaclePrefabs;
	public Transform player;
	private float startDelay = 2;
	private float spawnInterval = 4f;
	private float spawnDistance = 5f;
	
	
	
	void Start()
	{
     	InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
	}
	
    void Update()
    {

    }
	
	void SpawnObstacle(){
		// Ensure obstaclePrefabs array is not empty before spawning
		        if (obstaclePrefabs != null && obstaclePrefabs.Length > 0)
		        {
		            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
		            Vector3 spawnPosition = player.position + player.forward * spawnDistance;
					Quaternion spawnRotation = Quaternion.LookRotation(player.position - spawnPosition);
		            Instantiate(obstaclePrefabs[obstacleIndex], spawnPosition, spawnRotation);
		        }
		        else
		        {
		            Debug.LogWarning("Obstacle prefabs array is not set or empty.");
		        }
	}
}

