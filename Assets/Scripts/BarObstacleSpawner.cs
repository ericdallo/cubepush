using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleSpawner : MonoBehaviour, ISpawner {

	private BarObstacleFactory obstacleFactory;
	public GameObject DeSpawner;
    private float barScoreLeveleMultiplier = 0.03f;

    void Start() {
		obstacleFactory = GetComponent<BarObstacleFactory>();
	}

	public GameObject Spawn() {
		var spawnedObstacle = obstacleFactory.Build();

		spawnedObstacle.transform.position = transform.position;
		spawnedObstacle.transform.rotation = transform.rotation;
		
		var spawnedObstacleMovement = spawnedObstacle.GetComponent<BarMovement>();

		spawnedObstacleMovement.Destination = DeSpawner;
		changeSpeed(spawnedObstacleMovement);

		DeSpawner.GetComponent<BarObstacleDespawner>().AddAcceptColliders(spawnedObstacle.GetInstanceID());

		return spawnedObstacle;
	}

	private void changeSpeed(BarMovement spawnedObstacleMovement) {
		float lastBarSpeed = SpawnManager.Get().BarSpeed;

		if (GameManager.Get().IsGameOver()) {
			spawnedObstacleMovement.Speed = lastBarSpeed;
			return;
		}

		if (ScoreManager.Get().GetCurrentLevel() % 2 == 0) {
			spawnedObstacleMovement.Speed = lastBarSpeed;
			return;
		}

		SpawnManager.Get().BarSpeed = spawnedObstacleMovement.Speed + (ScoreManager.Get().GetCurrentLevel() * barScoreLeveleMultiplier);

		lastBarSpeed = SpawnManager.Get().BarSpeed;

		spawnedObstacleMovement.Speed = lastBarSpeed;
	}

}
