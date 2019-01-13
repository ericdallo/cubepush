using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody PlayerBody;
	public float Speed = 60f;
	public float MaxSpeed = 5f;
	public float JumpForce = 8f;

	void Update() {
		if (PlayerBody.position.y < -1f) {
			FindObjectOfType<GameManager>().GameOver();
		}
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

		Camera camera = Camera.main;

		Vector3 forward = camera.transform.forward;
        Vector3 right = camera.transform.right;
 
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

		Vector3  movement = forward * moveVertical + right * moveHorizontal;

		PlayerBody.AddForce(movement * Speed * Time.deltaTime, ForceMode.VelocityChange);

		float fallVelocity = PlayerBody.velocity.y;

 		if (PlayerBody.velocity.magnitude > MaxSpeed) {
			Vector3 newVelocity = PlayerBody.velocity.normalized * MaxSpeed;
			newVelocity.y = fallVelocity;
			PlayerBody.velocity = newVelocity;
		}

		bool isPlayerOnGround = Physics.Raycast(transform.position, new Vector2(0, -1), 1f, LayerMask.GetMask("Ground"));

		if (Input.GetButtonDown("Jump") && isPlayerOnGround) {
			PlayerBody.AddForce(Vector2.up * JumpForce, ForceMode.VelocityChange);
		}
	}
	
}
