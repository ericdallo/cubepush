using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {

    private bool fadeBackground = false;
    private GameObject background;
    private GameObject title;
    private GameObject playText;
    public float FadeSpeed;

    void Start() {
        background = GameObject.Find("Background");
        title = GameObject.Find("Title");
        playText = GameObject.Find("PlayText");
    }

    void Update() {
        if (fadeBackground) {
            float newAlpha = background.GetComponent<CanvasRenderer>().GetAlpha() - 0.1f * FadeSpeed * Time.deltaTime;

            background.GetComponent<CanvasRenderer>().SetAlpha(newAlpha);

            title.transform.position += Vector3.up;
            title.GetComponent<CanvasRenderer>().SetAlpha(newAlpha);

            playText.transform.position += Vector3.down;
            playText.GetComponent<CanvasRenderer>().SetAlpha(newAlpha);
        }

        if (gameObject.activeSelf && background.GetComponent<CanvasRenderer>().GetAlpha() <= 0) {
            gameObject.SetActive(false);
            fadeBackground = false;
        }
    }

    public void Play() {
        fadeBackground = true;
    }
}
