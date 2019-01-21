using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollider : MonoBehaviour {

    private FixedJoint joint;
    public float StickTime = 1;
    private bool canStick = true;
    public Color StartColor;
    public Color UnstickColor;
    private MeshRenderer[] meshs;
    private float lerpTime = 0;

    void Start() {
        meshs = GetComponentsInChildren<MeshRenderer>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" && canStick) {
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = collision.rigidbody;
            Invoke("Unstick", StickTime);
        }
    }

    void Update() {
        if (joint != null && canStick) {
            foreach(MeshRenderer mesh in meshs) {
                mesh.material.color = Color.Lerp(StartColor, UnstickColor, lerpTime);
            }

            if (lerpTime < 1) {
                lerpTime += Time.deltaTime / StickTime;
            }
        }
    }

    private void Unstick() {
        Destroy(joint);
        canStick = false;
    }

}
