using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlaysOnClick : MonoBehaviour
{
    AudioSource selfSource;
    public float cooldown = 0.25f;
    private float lastTest = 0f;
    private float lastTime;

    private void Start() {
        selfSource = GetComponent<AudioSource>();
        lastTime = Time.time;
    }

    public void Play() {
        float delta = Time.time - lastTime;
        lastTime = Time.time;
        lastTest += delta;
        if (delta > cooldown) {
            selfSource.volume = Beatmaker.volume;
            delta -= cooldown;
            selfSource.Play();
        }
    }
}
