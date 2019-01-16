using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Joystick Joystick;
	public float JoystickSpeed;
	public Rigidbody PlayerBody;
	public float Speed;
	public float MaxSpeed;
    private GameManager gameManager;
	private Camera mainCamera;

    void Start() {
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

		mainCamera = Camera.main;
	}

	void Update() {
		if (PlayerBody.position.y < -1f) {
			gameManager.GameOver();
		}
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal") + (Joystick.Horizontal * JoystickSpeed);
        float moveVertical = Input.GetAxis("Vertical") + (Joystick.Vertical * JoystickSpeed);

		Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
 
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
	}
	
}
