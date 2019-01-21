using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleFactory : MonoBehaviour {

    private const float BAR_SIZE = 10;
    private GameObject barPrefab;
    public float Gap = 2;

    void Awake() {
        barPrefab = (GameObject) Resources.Load("Prefabs/Obstacles/BarObstacle", typeof(GameObject));
    }

    public GameObject Build() {
        GameObject generatedBar = Instantiate(barPrefab, barPrefab.transform.position, barPrefab.transform.rotation);

        Transform generatedBarTransform = randomBar(generatedBar.transform);
        Transform leftTransform = generatedBarTransform.GetChild(0);
        Transform rightTransform = generatedBarTransform.GetChild(1);

        float randomLeftScaleX = Random.Range(0, BAR_SIZE - Gap);
        float randomLeftPositionX = -(BAR_SIZE / 2) + (randomLeftScaleX / 2);

        float rightScaleX = BAR_SIZE - randomLeftScaleX - Gap;
        float rightPositionX = (BAR_SIZE / 2) - (rightScaleX / 2);

        leftTransform.localScale = new Vector3(randomLeftScaleX, leftTransform.localScale.y, leftTransform.localScale.z);
        leftTransform.position = new Vector3(randomLeftPositionX, leftTransform.position.y, leftTransform.position.z);

        rightTransform.localScale = new Vector3(rightScaleX, rightTransform.localScale.y, rightTransform.localScale.z);
        rightTransform.position = new Vector3(rightPositionX, rightTransform.position.y, rightTransform.position.z);
        
        return generatedBar;
    }

    private Transform randomBar(Transform generatedBarTransform) {
		int barRandomPosition = Random.Range(1, generatedBarTransform.childCount);
        Transform randomBar = generatedBarTransform.GetChild(barRandomPosition);
		randomBar.gameObject.SetActive(true);

        return randomBar;
	}
}
