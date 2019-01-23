using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private GameObject gameOverText;
    private Vector3 gameOverDefaultPostion;
    private GameObject retryButtom;
    private Vector3 retryDefaultPosition;
    private Fader fader;
    private CanvasGroup canvasGroup;
    private bool retring = false;
    private bool showingUI = false;

    void Start() {
        gameOverText = GameObject.Find("GameOverText");
        gameOverDefaultPostion = gameOverText.transform.position;
        retryButtom = GameObject.Find("RetryButton");
        retryDefaultPosition = retryButtom.transform.position;
        fader = GetComponent<Fader>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    void Update() {
        if (fader.IsFadingOut()) {
            gameOverText.transform.position += Vector3.up;

            retryButtom.transform.position += Vector3.down;
        } 

        if (fader.IsFadingIn()) {
            showingUI = true;
        }

        if (showingUI && !fader.IsFadingIn()) {
            canvasGroup.blocksRaycasts = true;
        }
        
        if (retring  && !fader.IsFadingOut()) {
            retring = false;
            canvasGroup.blocksRaycasts = false;
            gameOverText.transform.position = gameOverDefaultPostion;
            retryButtom.transform.position = retryDefaultPosition;
        }
    }

    public void Retry() {
        if (retring) {
            return;
        }

        retring = true;
        GameManager.Get().Retry();
        fader.FadeOut();
    }
}
