using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollider : MonoBehaviour {

    private FixedJoint joint;
    public float StickTime = 1;
    private bool canStick = true;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" && canStick) {
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.rigidbody;
            Invoke("Unstick", StickTime);
        }
    }

    private void Unstick() {
        Destroy(joint);
        canStick = false;
    }

}
