using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public float FadeSpeed;
    public int CurrentLevel = 1;
    public GameObject ScoreUI;
    private TextMesh currentLevelText;
    private bool fadeIn = false;
    private CanvasGroup scoreUIRenderer;

    void Start() {
        currentLevelText = ScoreUI.transform.Find("CurrentLevel").GetComponent<TextMesh>();
        scoreUIRenderer = ScoreUI.GetComponent<CanvasGroup>();
    }

    void Update() {
        if (fadeIn) {
            float newAlpha = scoreUIRenderer.alpha + 0.1f * FadeSpeed * Time.deltaTime;

            scoreUIRenderer.alpha = newAlpha;
        }

        if (ScoreUI.activeSelf && scoreUIRenderer.alpha >= 1) {
            fadeIn = false;
        }
    }

    public void NextLevel() {
        CurrentLevel += 1;
        currentLevelText.text = "" + CurrentLevel;
    }

    public void Show() {
        scoreUIRenderer.alpha = 0;
        fadeIn = true;
    }
}
