using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl1ObstacleMovement : MonoBehaviour
{
    private float speed = 0.5f;
    private Transform player;

    void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
	}

    void Update()
    {
	   // Move the obstacle towards the player's position
	   if (player != null)
	   {
	      Vector3 direction = (player.position - transform.position).normalized;
	      transform.Translate(direction * speed * Time.deltaTime, Space.World);
	   }
    }
}
