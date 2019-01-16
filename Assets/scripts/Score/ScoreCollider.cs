using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollider : MonoBehaviour {

    private bool hasScored = false;
    private ScoreManager scoreManager;

    void Start() {
       scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
   }

   void OnCollisionEnter(Collision collision) {
		if (!hasScored && collision.gameObject.tag == "Player") {
            hasScored = true;

			scoreManager.NextLevel();
		}
	}


}
