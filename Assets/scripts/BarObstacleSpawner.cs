using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleSpawner : MonoBehaviour, ISpawner {

	private BarObstacleFactory obstacleFactory;
	public GameObject DeSpawner;

	void Start() {
		obstacleFactory = GetComponent<BarObstacleFactory>();
	}

	public GameObject Spawn() {
		var Obstacle = obstacleFactory.Build();
		
		Obstacle.GetComponent<BarMovement>().Destination = DeSpawner;
		var spawnedObstacle = Instantiate(Obstacle, transform.position, transform.rotation);
		DeSpawner.GetComponent<BarObstacleDespawner>().AddAcceptColliders(spawnedObstacle.GetInstanceID());

		return spawnedObstacle;
	}	

}
