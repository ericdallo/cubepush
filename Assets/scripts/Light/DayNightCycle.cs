using System;
using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    private const int MORNING = 21600;
    private const int MIDDAY = 43200;
    private const int NIGHT_START = 67000;
    private const int NIGHT_GAP = 4000;
    private const int MIDNIGHT = 86400;
    public float Time;
    public TimeSpan CurrentTime;
    private Transform sunTransform;
    private Light sunLight;
    public int Days;

    public float intensity;
    public Color Fogday = Color.grey;
    public Color FogNight = Color.black;

    public int Speed;

    void Start() {
        sunTransform = GetComponent<Transform>();
        sunLight = GetComponent<Light>();
    }

    void Update() {
        Time += UnityEngine.Time.deltaTime * Speed;

        if (Time > NIGHT_START + NIGHT_GAP) {
            Time = MORNING - NIGHT_GAP;
            Days += 1;
        }

        CurrentTime = TimeSpan.FromSeconds(Time);
        
        sunTransform.rotation = Quaternion.Euler(new Vector3((Time - MORNING) / MIDNIGHT * 360, 0, 0));

        if (Time < MIDDAY) {
            intensity = 1 - (MIDDAY - Time) / MIDDAY;
        } else {
            intensity = 1 - ((MIDDAY - Time) / MIDDAY * -1);
        }

        RenderSettings.fogColor = Color.Lerp(FogNight, Fogday, intensity * intensity);

        sunLight.intensity = intensity;
    }
}
