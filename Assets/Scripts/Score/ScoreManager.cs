using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int StartLevel = 1;
    private int currentLevel;
    public GameObject ScoreUI;
    private TMPro.TextMeshProUGUI currentLevelText;
    private static ScoreManager reference;

    void Start() {
        currentLevelText = ScoreUI.transform.Find("CurrentLevel").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        currentLevel = StartLevel;
    }

    public static ScoreManager Get() {
        if (reference == null) {
            reference = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }

        return reference;
    }

    public int NextLevel() {
        AudioManager.Get().Play("LevelUp");
        currentLevel += 1;
        updateUI();

        return currentLevel;
    }

    public void Show() {
        ScoreUI.GetComponent<Fader>().FadeIn();
    }

    public int GetCurrentLevel() {
        return currentLevel;
    }

    public void ResetLevel() {
        currentLevel = StartLevel;
        updateUI();
    }

    private void updateUI() {
        currentLevelText.text = "" + currentLevel;
    }
}
