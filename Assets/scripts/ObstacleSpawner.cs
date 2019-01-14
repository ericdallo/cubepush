using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour, ISpawner {

	public List<GameObject> Obstacles;
	public GameObject DeSpawner;

	public GameObject Spawn() {
		var randomPosition = UnityEngine.Random.Range(0, Obstacles.Count);
		var Obstacle = Obstacles[randomPosition];
		
		Obstacle.GetComponent<BarMovement>().Destination = DeSpawner;
		var spawnedObstacle = Instantiate(Obstacle, transform.position, transform.rotation);
		DeSpawner.GetComponent<ObstacleDespawner>().AddAcceptColliders(spawnedObstacle.GetInstanceID());

		return spawnedObstacle;
	}	

}
