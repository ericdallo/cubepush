using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private bool fadeBackground = false;
    private GameObject background;
    private GameObject title;
    private GameObject playButtom;
    public float FadeSpeed;
    private GameManager gameManager;

    void Start() {
        background = GameObject.Find("Background");
        title = GameObject.Find("Title");
        playButtom = GameObject.Find("PlayButton");
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update() {
        if (fadeBackground) {
            float newAlpha = background.GetComponent<CanvasRenderer>().GetAlpha() - 0.1f * FadeSpeed * Time.deltaTime;

            background.GetComponent<CanvasRenderer>().SetAlpha(newAlpha);

            title.transform.position += Vector3.up;
            title.GetComponent<CanvasRenderer>().SetAlpha(newAlpha);

            playButtom.transform.position += Vector3.down;
            playButtom.GetComponent<CanvasRenderer>().SetAlpha(newAlpha);
        }

        if (gameObject.activeSelf && background.GetComponent<CanvasRenderer>().GetAlpha() <= 0) {
            gameObject.SetActive(false);
            fadeBackground = false;
        }
    }

    public void Play() {
        playButtom.GetComponent<Button>().interactable = false;
        gameManager.Play();
        fadeBackground = true;
    }
}
