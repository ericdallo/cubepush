using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public int CurrentLevel = 1;
    public GameObject ScoreUI;
    private TMPro.TextMeshProUGUI currentLevelText;

    void Start() {
        currentLevelText = ScoreUI.transform.Find("CurrentLevel").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void NextLevel() {
        CurrentLevel += 1;
        currentLevelText.text = "" + CurrentLevel;
    }

    public void Show() {
        ScoreUI.GetComponent<Fader>().FadeIn();
    }
}
