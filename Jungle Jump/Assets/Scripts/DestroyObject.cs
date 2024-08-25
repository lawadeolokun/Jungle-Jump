using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float distanceThreshold = 4f; // Distance at which the obstacle will be destroyed

    void Update()
    {
		// Check if the obstacle is behind the player by a certain distance
		            if (transform.position.x < player.position.x - distanceThreshold)
        {
            // Ensure the game object is not already destroyed
            if (gameObject != null)
            {
                Destroy(gameObject);
            }
        }
    }
}
