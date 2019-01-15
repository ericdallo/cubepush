using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	private bool hasGameEnded = false;
	public float RestartDelay;
	public GameObject GamePad;
	public GameObject Menu;

	void Awake() {
		Time.timeScale = 0;
	}

	void Update() {
		if (Input.touchCount > 0 || Input.GetMouseButtonDown(0)) {
			GamePad.SetActive(true);
			Menu.GetComponent<Menu>().Play();
			Time.timeScale = 1;
		}
	}

	public void GameOver() {
		if (!hasGameEnded) {
			hasGameEnded = true;
			Invoke("Restart", RestartDelay);
		}
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
