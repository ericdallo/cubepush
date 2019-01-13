﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool hasGameEnded = false;
	public float restartDelay = 0.5f;

	public void GameOver() {
		if (!hasGameEnded) {
			hasGameEnded = true;
			Invoke("Restart", restartDelay);
		}
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
