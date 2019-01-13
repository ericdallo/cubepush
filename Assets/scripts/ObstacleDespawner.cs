using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDespawner : MonoBehaviour {

	public float FadeTime;
	private GameObject collidedObstacle;
	private Color collidedObstacleColor;
	
	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag == "Obstacle") {
			collidedObstacle = collider.gameObject;
			collidedObstacleColor = collider.gameObject.GetComponent<Renderer>().material.color;
			collidedObstacleColor.a = 1f;
		}
	}

	void Update() {
		if (collidedObstacleColor != null && collidedObstacleColor.a > 0) {
			Debug.Log(collidedObstacleColor.a);
			collidedObstacleColor.a = collidedObstacleColor.a - (Time.deltaTime / FadeTime);
            collidedObstacle.GetComponent<Renderer>().material.color = collidedObstacleColor;
        } else {
            Destroy(collidedObstacle);
        }
	}
}
