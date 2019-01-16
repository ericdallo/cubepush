using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool hasGameEnded = false;
	private bool gameStarted = false;
	public float RestartDelay;
	public GameObject GamePadUI;
	private ScoreManager scoreManager;

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
	}

	public void GameOver() {
		if (!hasGameEnded) {
			hasGameEnded = true;
			Invoke("Restart", RestartDelay);
		}
	}

	public void Play() {
		gameStarted = true;
		GamePadUI.GetComponent<Fader>().FadeIn();
		scoreManager.Show();
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public bool HasGameStarted() {
		return gameStarted;
	}
}
