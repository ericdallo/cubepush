using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollider : MonoBehaviour {

    private FixedJoint joint;
    public float StickTime = 0.5f;
    private bool canStick = true;
    public Color UnstickColor;
    public Color StartColor;
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
