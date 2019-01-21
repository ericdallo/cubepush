using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] Sounds;

    private static AudioManager reference;

    public static AudioManager Get() {
		if (reference == null) {
			reference = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();	
		}

		return reference;
	}

    void Awake() {
        foreach(Sound sound in Sounds) {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;

            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
            sound.Source.loop = sound.Loop;
        }
    }

    public void Play(string name) {
        Sound sound = Array.Find(Sounds, s => s.Name == name);
        sound.Source.Play();
    }
}
