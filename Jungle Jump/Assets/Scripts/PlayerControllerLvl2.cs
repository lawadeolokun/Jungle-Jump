using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerLvl2 : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false;
    public float speed = 0.3f;
    public float horizontalInput;
    public float verticalInput;
	public float xRange = 5;

    private int keysCollected = 0; // Track the number of keys collected
    public int keysNeededToWin = 10; // Number of keys required to win

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
    }

    void Update()
    {
        if (gameOver)
            return;

        // Horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(-Vector3.left * horizontalInput * Time.deltaTime * speed);
		
		if (transform.position.x < -xRange){
			transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
		}
		if (transform.position.x > xRange){
			transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
		}

        // Vertical movement
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(-Vector3.back * verticalInput * Time.deltaTime * speed);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        // Check if the player has rotated too much on the X-axis
        float playerRotationX = transform.eulerAngles.x;

        if (playerRotationX > 180f)
        {
            playerRotationX -= 360f;
        }

        if (Mathf.Approximately(playerRotationX, -90f) || Mathf.Approximately(playerRotationX, 90f))
        {
            gameOver = true;
            Debug.Log("Game Over, You fell");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
			Time.timeScale = 0f;
        }
        else if (collision.gameObject.CompareTag("Key"))
        {
            keysCollected++;
            Destroy(collision.gameObject);
            Debug.Log("Keys collected: " + keysCollected);

            if (keysCollected >= keysNeededToWin)
            {
                gameOver = true;
                Debug.Log("You win! Game Over.");
                // Add any additional win logic here, such as displaying a win screen or restarting the level.
            }
        }
    }
}