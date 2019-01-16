using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public float SpawnTime;
	public float SpawnDelay;
	private GameObject[] spawners;
	private bool isSpawing = false;
    private GameManager gameManager;

    void Start () {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
		gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}

	void Update() {
		if (!isSpawing && gameManager.HasGameStarted()) {
			isSpawing = true;

			InvokeRepeating("SpawnObstacle", SpawnTime, SpawnDelay);
		}
	}

	void SpawnObstacle() {
		var spawner = spawners[Random.Range(0, spawners.Length)];

		spawner.GetComponent<ISpawner>().Spawn();
	}
}
