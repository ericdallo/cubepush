﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMovement : MonoBehaviour {

	private Rigidbody barBody;
	private Vector3 startPosition;
    public GameObject Destination;
	public float Speed;
    private float startSpeed;
	
	void Start() {
		barBody = GetComponent<Rigidbody>();
		startPosition = transform.position;
		startSpeed = Speed;
	}
	void FixedUpdate () {
		Vector3 movement = Destination.transform.position - startPosition;

		barBody.MovePosition(barBody.position + movement.normalized * Speed * Time.deltaTime);
	}
}
