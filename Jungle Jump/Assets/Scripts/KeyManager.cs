using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // If you want to display "Level Complete" on the screen

public class KeyManager : MonoBehaviour
{
    public bool hasKey1 = false;
    public bool hasKey2 = false;
    public bool hasKey3 = false;

    public Text levelCompleteText; // Reference to a UI Text component

    void Start()
    {
        // Hide the "Level Complete" text at the start
        if (levelCompleteText != null)
        {
            levelCompleteText.gameObject.SetActive(false);
        }
    }

    public void CollectKey(string keyTag)
    {
        if (keyTag == "Key1")
        {
            hasKey1 = true;
            Debug.Log("Key 1 collected!");
        }
        else if (keyTag == "Key2")
        {
            hasKey2 = true;
            Debug.Log("Key 2 collected!");
        }
        else if (keyTag == "Key3")
        {
            hasKey3 = true;
            Debug.Log("Key 3 collected!");
        }

        // Check if all keys are collected
        if (hasKey1 && hasKey2 && hasKey3)
        {
            Debug.Log("All keys collected. Level Complete!");

            // Display "Level Complete" and stop the game
            if (levelCompleteText != null)
            {
                levelCompleteText.gameObject.SetActive(true);
                levelCompleteText.text = "Level Complete!";
            }

            // Stop the game by freezing time
            Time.timeScale = 0f;
        }
    }
}
