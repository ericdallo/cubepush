using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleFactory : MonoBehaviour {

    private const float BAR_SIZE = 10;
    private GameObject baseBar;
    private Transform LeftTransform;
    private Transform RightTransform;
    public float Gap = 2;

    void Start() {
        baseBar = (GameObject) Resources.Load("prefabs/obstacles/barObstacleBase", typeof(GameObject));
        LeftTransform = baseBar.GetComponentInChildren<Transform>().Find("Left");
        RightTransform = baseBar.GetComponentInChildren<Transform>().Find("Right");
    }

    public GameObject Build() {
        float randomLeftScaleX = Random.Range(0, BAR_SIZE - Gap);
        float randomLeftPositionX = -(BAR_SIZE / 2) + (randomLeftScaleX / 2);

        float rightScaleX = BAR_SIZE - randomLeftScaleX - Gap;
        float rightPositionX = (BAR_SIZE / 2) - (rightScaleX / 2);

        LeftTransform.localScale = new Vector3(randomLeftScaleX, LeftTransform.localScale.y, LeftTransform.localScale.z);
        LeftTransform.position = new Vector3(randomLeftPositionX, LeftTransform.position.y, LeftTransform.position.z);

        RightTransform.localScale = new Vector3(rightScaleX, RightTransform.localScale.y, RightTransform.localScale.z);
        RightTransform.position = new Vector3(rightPositionX, RightTransform.position.y, RightTransform.position.z);
        
        return baseBar;
    }
}
