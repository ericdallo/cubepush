using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public float SpawnTime;
	public float SpawnDelay;
	private GameObject[] spawners;
	
	void Start () {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
		InvokeRepeating("SpawnObstacle", SpawnTime, SpawnDelay);
	}

	void SpawnObstacle() {
		var spawner = spawners[Random.Range(0, spawners.Length)];

		spawner.GetComponent<ISpawner>().Spawn();
	}
}
