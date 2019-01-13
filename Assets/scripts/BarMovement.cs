using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour {

	public float Speed;
	public Rigidbody BarBody;

	void FixedUpdate() {
		var movement = new Vector3(0, 0, -Speed);

		BarBody.MovePosition(BarBody.position  + movement * Time.deltaTime);
	}
}
