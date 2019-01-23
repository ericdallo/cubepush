using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int StartLevel = 1;
    private int currentLevel;
    public GameObject ScoreUI;
    private TMPro.TextMeshProUGUI currentLevelText;

    #region Singleton
    public static ScoreManager Instance;
    private void Awake() {
        Instance = this;
    }
    #endregion

    void Start() {
        currentLevelText = ScoreUI.transform.Find("CurrentLevel").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        currentLevel = StartLevel;
    }

    public int NextLevel() {
        AudioManager.Instance.Play("LevelUp");
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

    public void SaveHighScore() {
        if (PlayerPrefs.GetInt("HighScore", 0) < currentLevel) {
            PlayerPrefs.SetInt("HighScore", currentLevel);
        }
    }

    private void updateUI() {
        currentLevelText.text = currentLevel.ToString();
    }
}
