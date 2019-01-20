using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public float SpawnTime;
	public float SpawnDelay;
	private GameObject[] spawners;
	private bool shouldSpawn = true;
	public float BarSpeed = 4;

	private static SpawnManager reference;

	public static SpawnManager Get() {
		if (reference == null) {
			reference = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
		}
		
		return reference;
	}

    void Start () {
		spawners = GameObject.FindGameObjectsWithTag("Spawner");
	}

	void Update() {
		if (shouldSpawn && GameManager.Get().HasGameStarted()) {
			shouldSpawn = false;

			InvokeRepeating("spawnObstacle", SpawnTime, SpawnDelay);
		}
	}

	public void ResetSpawn() {
		CancelInvoke("spawnObstacle");
		Invoke("startSpawn", 3);
	}
	private void spawnObstacle() {
		var spawner = spawners[Random.Range(0, spawners.Length)];

		spawner.GetComponent<ISpawner>().Spawn();
	}

	private void startSpawn() {
		shouldSpawn = true;
	}
}
