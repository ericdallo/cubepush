using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    private GameObject title;
    private GameObject playButtom;
    private Fader fader;

    void Start() {
        title = GameObject.Find("Title");
        playButtom = GameObject.Find("PlayButton");
        fader = GetComponent<Fader>();
    }

    void Update() {
        if (fader.IsFadingOut()) {
            title.transform.position += Vector3.up;

            playButtom.transform.position += Vector3.down;
        }

    }
    public void Play() {
        playButtom.GetComponent<Button>().interactable = false;
        fader.FadeOut();
        GameManager.Get().Play();
    }
}
