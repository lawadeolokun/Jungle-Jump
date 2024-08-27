using UnityEngine;

public class Lvl2KeyCollection : MonoBehaviour
{
    public int keysRequired = 5;
    private int keyCount = 0;

    private void Start()
    {
        // Initialization if needed
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // Remove the collected key from the scene
            keyCount++;

            // Notify in the console
            Debug.Log("Key Collected! Total Keys: " + keyCount);

            if (keyCount >= keysRequired)
            {
                EndGame();
            }
        }
    }

    private void EndGame()
    {
        Debug.Log("Game Over! All keys collected.");
		Time.timeScale = 0f;
        // Example: Load a new scene or show a game over screen.
        // SceneManager.LoadScene("GameOverScene");
    }
}
