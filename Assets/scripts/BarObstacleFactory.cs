using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarObstacleSpawner : MonoBehaviour {

    public GameObject BaseBar;

    void Start() {
        BaseBar = (GameObject) Resources.Load("prefabs/barObstacleBase", typeof(GameObject));
    }

    public GameObject Build() {
        
    }
}
