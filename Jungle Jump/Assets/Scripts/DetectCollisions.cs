using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private KeyManager keyManager;

    void Start()
    {
        keyManager = FindObjectOfType<KeyManager>();
       
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && keyManager != null)
        {
            // Check the tag of the current object (Key1, Key2, or Key3)
            if (gameObject.CompareTag("Key1") || gameObject.CompareTag("Key2") || gameObject.CompareTag("Key3"))
            {
                keyManager.CollectKey(gameObject.tag); // Pass the tag to the KeyManager
                Destroy(gameObject); // Destroy the key after collecting
            }
        }
    }
}
