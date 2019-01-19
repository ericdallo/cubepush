using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleSpawner : MonoBehaviour, ISpawner {

	private BarObstacleFactory obstacleFactory;
	public GameObject DeSpawner;
    private float BarScoreLeveleMultiplier = 0.03f;

    void Start() {
		obstacleFactory = GetComponent<BarObstacleFactory>();
	}

	public GameObject Spawn() {
		var Obstacle = obstacleFactory.Build();
		
		Obstacle.GetComponent<BarMovement>().Destination = DeSpawner;

		Obstacle.GetComponent<BarMovement>().Speed += calculateSpeed();
		var spawnedObstacle = Instantiate(Obstacle, transform.position, transform.rotation);
		DeSpawner.GetComponent<BarObstacleDespawner>().AddAcceptColliders(spawnedObstacle.GetInstanceID());

		return spawnedObstacle;
	}

	private float calculateSpeed() {
		if (ScoreManager.Get().CurrentLevel % 2 == 0) {
			return 0;
		}

		return ScoreManager.Get().CurrentLevel * BarScoreLeveleMultiplier;
	}

}
