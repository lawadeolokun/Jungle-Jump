using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private Rigidbody playerRb;
	public float jumpForce;
	public float gravityModifier;
	public bool isOnGround = true;
	public bool gameOver = false;
	public float speed = 0.3f;
	public float horizontalInput;
	public float verticalInput;
	
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
		Physics.gravity *= gravityModifier; 
    }
	
    void Update()
    {
	
		if (gameOver)
			return;
				
		horizontalInput = Input.GetAxis("Horizontal");
		transform.Translate(-Vector3.left * horizontalInput * Time.deltaTime * speed);
		
		verticalInput = Input.GetAxis("Vertical");
		transform.Translate(-Vector3.back * verticalInput * Time.deltaTime * speed);
		
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
		playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		isOnGround = false;
		}
		
	   // Check the player's X-axis rotation
	          float playerRotationX = transform.eulerAngles.x;

	          // Convert the rotation to the -180 to 180 range if necessary
	          if (playerRotationX > 180f)
	          {
	              playerRotationX -= 360f;
	          }

	          // Trigger game over if the X rotation is approximately -90 or 90 degrees
	          if (Mathf.Approximately(playerRotationX, -90f) || Mathf.Approximately(playerRotationX, 90f))
	          {
	              gameOver = true;
	              Debug.Log("Game Over, You fell");
	          }
	      }
	
	private void OnCollisionEnter(Collision collision){
		if(collision.gameObject.CompareTag("Ground")){
			isOnGround = true;
		}
		else if(collision.gameObject.CompareTag("Obstacle")){
		gameOver = true;
		Debug.Log("Game Over!");
		}
	
	}	
}
