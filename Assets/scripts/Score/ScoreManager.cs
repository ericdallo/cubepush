using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int CurrentLevel = 1;
    public GameObject ScoreUI;
    private TMPro.TextMeshProUGUI currentLevelText;
    private static ScoreManager reference;

    void Start() {
        currentLevelText = ScoreUI.transform.Find("CurrentLevel").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public static ScoreManager Get() {
        if (reference == null) {
            reference = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        }

        return reference;
    }

    public void NextLevel() {
        AudioManager.Get().Play("LevelUp");
        CurrentLevel += 1;
        currentLevelText.text = "" + CurrentLevel;
    }

    public void Show() {
        ScoreUI.GetComponent<Fader>().FadeIn();
    }
}
