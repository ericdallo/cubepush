using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool hasGameEnded = false;
	private bool gameStarted = false;
	public float RestartDelay;
	public GameObject GamePad;

	void Awake() {
		Time.timeScale = 0;
		gameStarted = false;
	}

	public void GameOver() {
		if (!hasGameEnded) {
			hasGameEnded = true;
			Invoke("Restart", RestartDelay);
		}
	}

	public void Play() {
		Time.timeScale = 1;
		GamePad.SetActive(true);
		gameStarted = true;
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public bool HasGameStarted() {
		return gameStarted;
	}
}
