using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 4, -4); // Adjusted offset to move the camera higher
    public float xRotation = 30f; // Rotation angle on the X axis

    void Start()
    {
        // Optionally, initialize values if needed
    }

    void Update()
    {
        // Calculate the new position
        Vector3 targetPosition = player.transform.position + player.transform.TransformDirection(offset);

        // Set the camera's position to follow the player
        transform.position = targetPosition;

        // Calculate the new rotation
        Quaternion targetRotation = Quaternion.Euler(xRotation, player.transform.eulerAngles.y, 0f);

        // Set the camera's rotation
        transform.rotation = targetRotation;
    }
}
