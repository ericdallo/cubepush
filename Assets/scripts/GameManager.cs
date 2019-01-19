using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool hasGameEnded = false;
	private bool gameStarted = false;
	public float GameOverDelay;
	public GameObject GamePadUI;
	public GameObject GameOverUI;
	private ScoreManager scoreManager;
    private GameObject player;
    private static GameManager reference;

	public static GameManager Get() {
		if (reference == null) {
			reference = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();	
		}

		return reference;
	}

	void Awake() {
		gameStarted = false;
		scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	public void GameOver() {
		if (!hasGameEnded) {
			hasGameEnded = true;
			Invoke("ShowGameOverUI", GameOverDelay);
		}
	}

	public void Play() {
		gameStarted = true;
		GamePadUI.GetComponent<Fader>().FadeIn();
		scoreManager.Show();
	}

	void ShowGameOverUI() {
		GameOverUI.GetComponent<Fader>().FadeIn();
		GamePadUI.GetComponent<Fader>().FadeOut();
		Invoke("DestroyPlayer", 3);
	}

	public bool HasGameStarted() {
		return gameStarted;
	}

	public void DestroyPlayer() {
		Destroy(player);
	}

	public void Retry() {
		scoreManager.CurrentLevel = 1;
	}
}
