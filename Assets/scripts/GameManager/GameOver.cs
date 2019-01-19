using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    private GameObject gameOverText;
    private GameObject retryButtom;
    private Fader fader;

    void Start() {
        gameOverText = GameObject.Find("GameOverText");
        retryButtom = GameObject.Find("RetryButton");
        fader = GetComponent<Fader>();
    }

    void Update() {
        if (fader.IsFadingOut()) {
            gameOverText.transform.position += Vector3.up;

            retryButtom.transform.position += Vector3.down;
        }
    }

    public void Retry() {
        retryButtom.GetComponent<Button>().interactable = false;
        fader.FadeOut();
        GameManager.Get().Retry();
    }
}
