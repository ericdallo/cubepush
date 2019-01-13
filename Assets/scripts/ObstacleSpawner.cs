using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject Obstacle;
	public float SpawnTime;
	public float SpawnDelay;
	private float currentTime;

	void Start() {
		InvokeRepeating("SpawnObstacle", SpawnTime, SpawnDelay);
	}

	void SpawnObstacle() {
		Instantiate(Obstacle, transform.position, transform.rotation);
	}

}
