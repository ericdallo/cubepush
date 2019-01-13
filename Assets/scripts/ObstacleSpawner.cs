using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public GameObject Obstacle;
	public GameObject DeSpawner;
	public float SpawnTime;
	public float SpawnDelay;

	void Start() {
		InvokeRepeating("SpawnObstacle", SpawnTime, SpawnDelay);
	}

	void SpawnObstacle() {
		Obstacle.GetComponent<BarMovement>().Destination = DeSpawner;
		Instantiate(Obstacle, transform.position, transform.rotation);
	}

}
