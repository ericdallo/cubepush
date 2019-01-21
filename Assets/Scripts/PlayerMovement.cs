using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private Joystick joystick;
	private Camera mainCamera;
	private Rigidbody playerBody;
	public float Speed;
	public float MaxSpeed;
	public float JoystickSpeed;
    private bool dead = false;

    void Start() {
		mainCamera = Camera.main;
		playerBody = GetComponent<Rigidbody>();
		joystick = GameObject.FindGameObjectWithTag("MovementJoystick").GetComponent<Joystick>();
	}

	void Update() {
		if (dead) {
			return;
		}

		if (playerBody.position.y < -1f && !GameManager.Get().IsGameOver()) {
			GameManager.Get().GameOver();
		}
	}
	
	void FixedUpdate () {
		if (!GameManager.Get().HasGameStarted()) {
			return;
		}

		float moveHorizontal = Input.GetAxis("Horizontal") + (joystick.Horizontal * JoystickSpeed);
        float moveVertical = Input.GetAxis("Vertical") + (joystick.Vertical * JoystickSpeed);

		Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;
 
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

		Vector3  movement = forward * moveVertical + right * moveHorizontal;

		playerBody.AddForce(movement * Speed * Time.deltaTime, ForceMode.VelocityChange);

		float fallVelocity = playerBody.velocity.y;

 		if (playerBody.velocity.magnitude > MaxSpeed) {
			Vector3 newVelocity = playerBody.velocity.normalized * MaxSpeed;
			newVelocity.y = fallVelocity;
			playerBody.velocity = newVelocity;
		}
	}

	public void Die() {
		dead = true;
		Invoke("destroyPlayer", 3);
	}

	private void destroyPlayer() {
		Destroy(gameObject);
	}
	
}
