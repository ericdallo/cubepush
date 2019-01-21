using System;
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
	public GameObject PlayerPrefab;
    private GameObject player;
    private static GameManager reference;
	private Transform playerRespawn;

	public static GameManager Get() {
		if (reference == null) {
			reference = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();	
		}

		return reference;
	}

	void Awake() {
		gameStarted = false;
		player = GameObject.FindGameObjectWithTag("Player");
		playerRespawn = GameObject.FindGameObjectWithTag("Respawn").transform;
	}

	public void GameOver() {
		hasGameEnded = true;
		player.GetComponent<PlayerMovement>().Die();
		Invoke("ShowGameOverUI", GameOverDelay);
	}

    public bool IsGameOver() {
        return hasGameEnded;
    }

    public void Play() {
		gameStarted = true;
		GamePadUI.GetComponent<Fader>().FadeIn();
		ScoreManager.Get().Show();
	}

	void ShowGameOverUI() {
		GameOverUI.GetComponent<Fader>().FadeIn();
		GamePadUI.GetComponent<Fader>().FadeOut();
	}

	public bool HasGameStarted() {
		return gameStarted;
	}

	public void Retry() {
		ScoreManager.Get().ResetLevel();
		SpawnManager.Get().ResetSpawn();
		GamePadUI.GetComponent<Fader>().FadeIn();
		this.player = Instantiate(PlayerPrefab, playerRespawn.position, playerRespawn.rotation);
		hasGameEnded = false;
	}
}
