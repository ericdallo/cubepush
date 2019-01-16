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

    public void NextLevel() {
        CurrentLevel += 1;
        currentLevelText.text = "" + CurrentLevel;
    }

    public void Show() {
        ScoreUI.GetComponent<Fader>().FadeIn();
    }
}
