using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    private bool fadeIn = false;
    private bool fadeOut = false;
    public float FadeSpeed = 10;
    private CanvasGroup fadeObjectCanvas;

    void Start() {
        fadeObjectCanvas = GetComponent<CanvasGroup>();
    }

   void Update() {
       if (fadeObjectCanvas == null) {
           return;
       }

        if (fadeIn) {
            float newAlpha = fadeObjectCanvas.alpha + 0.1f * FadeSpeed * Time.deltaTime;

            fadeObjectCanvas.alpha = newAlpha;

            if (fadeObjectCanvas.alpha >= 1) {
                gameObject.SetActive(true);
                fadeIn = false;
            }
        }

        if (fadeOut) {
            float newAlpha = fadeObjectCanvas.alpha - 0.1f * FadeSpeed * Time.deltaTime;

            fadeObjectCanvas.alpha = newAlpha;

            if (fadeObjectCanvas.alpha <= 0) {
                gameObject.SetActive(false);
                fadeOut = false;
            }
        }

    }

    public void FadeIn() {
        fadeIn = true;
    }

    public void FadeOut() {
        fadeOut = true;
    }

    public bool IsFadingIn() {
        return fadeIn;
    }

    public bool IsFadingOut() {
        return fadeOut;
    }

}
