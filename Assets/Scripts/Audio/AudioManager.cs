using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

    public Sound[] Sounds;

    private static AudioManager reference;

    #region Singleton
    public static AudioManager Instance;
    #endregion

    void Awake() {
        Instance = this;
        
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
