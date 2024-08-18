using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float speed;
    private Vector3 direction;

    // Set the speed at which the obstacle moves
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    // Set the direction in which the obstacle should move
    public void SetDirection(Vector3 newDirection)
    {
        direction = newDirection;
    }

    void Update()
    {
        // Move the obstacle in the set direction
        transform.position += direction * speed * Time.deltaTime;

        // Optional: Destroy the obstacle if it goes beyond a certain distance
        if (Vector3.Distance(transform.position, Camera.main.transform.position) > 100f)
        {
            Destroy(gameObject);
        }
    }
}
