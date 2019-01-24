using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int StartLevel = 1;
    private int currentLevel;
    public GameObject ScoreUI;
    private TMPro.TextMeshProUGUI currentLevelText;
    private TMPro.TextMeshProUGUI highScoreText;

    #region Singleton
    public static ScoreManager Instance;
    private void Awake() {
        Instance = this;
    }

    #endregion

    void Start() {
        currentLevelText = ScoreUI.transform.Find("CurrentLevel").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        highScoreText = ScoreUI.transform.Find("HighScoreValue").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
        currentLevel = StartLevel;
    }

    public int NextLevel() {
        AudioManager.Instance.Play("LevelUp");
        currentLevel += 1;
        updateCurrentLevelUI();

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
        updateCurrentLevelUI();
        highScoreText.color = Color.white;
    }

    public void SaveHighScore() {
        if (PlayerPrefs.GetInt("HighScore", 0) < currentLevel) {
            PlayerPrefs.SetInt("HighScore", currentLevel);
            highScoreText.color = Color.yellow;
        }

        updateHighScoreUI();
    }

    public void UpdateHighScoreUI() {
        updateHighScoreUI();
    }

    private void updateHighScoreUI() {
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void updateCurrentLevelUI() {
        currentLevelText.text = currentLevel.ToString();
    }
    
}
