using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour {

    public float RotateSpeed = 10;
    public float RotateSpeedToDefault;
    private GameManager gameManager;
    private Vector3 cameraOffset;
    private const float DEFAULT_ROTATION_Y = -45;
    private bool isInDefaultPosition = false;
    public float DifferenceGap = 0.3f;

    void Start() {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        cameraOffset = transform.position;
    }

    void Update() {
        if (!gameManager.HasGameStarted()) {

            Quaternion cameraTurnAngle = Quaternion.AngleAxis(Time.deltaTime * -RotateSpeed, Vector3.up);

            cameraOffset = cameraTurnAngle * cameraOffset;

            transform.position = Vector3.Slerp(transform.position, cameraOffset, 1f);

            transform.LookAt(Vector3.zero);
        }

        if (!isInDefaultPosition && gameManager.HasGameStarted()) {

            float newRotation = (360 - transform.localEulerAngles.y + DEFAULT_ROTATION_Y) * 2;

            float differenceBetweenDefaultRotation;
            
            if (transform.localEulerAngles.y >= 180 + DEFAULT_ROTATION_Y) {
                Debug.Log("esquerda");
                differenceBetweenDefaultRotation = newRotation;
            } else {
                Debug.Log("direita");
                differenceBetweenDefaultRotation = -newRotation;
            }

            Quaternion cameraTurnAngle = Quaternion.AngleAxis(differenceBetweenDefaultRotation * Time.deltaTime, Vector3.up);

            cameraOffset = cameraTurnAngle * cameraOffset;

            transform.position = Vector3.Slerp(transform.position, cameraOffset, 1f);

            transform.LookAt(Vector3.zero);
            
            if (-DifferenceGap <= differenceBetweenDefaultRotation && differenceBetweenDefaultRotation <= DifferenceGap) {
                Debug.Log("acabou");
                isInDefaultPosition = true;
            }
        }
    }
}
