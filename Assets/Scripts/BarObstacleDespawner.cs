using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleDespawner : MonoBehaviour {

	public float FadeTime;
	public GameObject Spawner;
	private GameObject collidedObstacle;
	private Color collidedObstacleColor;
	private List<int> acceptedColliders = new List<int>();
	
	void OnTriggerEnter(Collider collider) {
		if (acceptedColliders.Contains(collider.gameObject.GetInstanceID())) {
			collidedObstacle = collider.gameObject;

			collidedObstacleColor = collidedObstacle.GetComponent<Renderer>().material.color;
			collidedObstacleColor.a = 1f;
		}
	}

	void Update() {
		if (collidedObstacle != null && collidedObstacleColor.a > 0) {

			foreach(Renderer childRend in collidedObstacle.GetComponentsInChildren<Renderer>() ){
			
				if (childRend) {
					var newColor = childRend.material.color;
					newColor.a = collidedObstacleColor.a - (Time.deltaTime / FadeTime);
					childRend.material.color = newColor;
				}
			}

			collidedObstacleColor.a = collidedObstacleColor.a - (Time.deltaTime / FadeTime);
            collidedObstacle.GetComponent<Renderer>().material.color = collidedObstacleColor;
        }

		if (collidedObstacle != null && collidedObstacleColor.a <= 0) {
            Destroy(collidedObstacle);
        }
	}

	public void AddAcceptColliders(int id) {
		this.acceptedColliders.Add(id);
	}
}
