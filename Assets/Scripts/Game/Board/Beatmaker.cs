using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Beatmaker : MonoBehaviour
{
    public float beatInterval = 1;
    private float currentTimeDelta = 0;

    int lastLevel;
    public AudioClip stopSound;
    AudioSource selfSource;
    GameState gameState;
    BoomBox selfBoombox;
    public static float volume = 0.5f;
    void Start()
    {
        gameState = GameState.GetInstance();
        selfSource = GetComponent<AudioSource>();
        selfBoombox = GetComponent<BoomBox>();
        currentTimeDelta = beatInterval;
        lastLevel = -1;
        selfSource.volume = volume;
    }

    void FixedUpdate()
    {
        if (gameState.dead == true) {
            selfSource.Stop();
            selfSource.clip = stopSound;
            selfSource.Play();
            this.enabled = false;
        }
        currentTimeDelta += Time.fixedDeltaTime;
        if (beatInterval <= currentTimeDelta) {
            currentTimeDelta -= beatInterval;
            selfSource.Stop();
            if (lastLevel != gameState.level) {
                selfSource.clip = selfBoombox.GetClip(gameState.level - 1);
                beatInterval = selfBoombox.GetLength(gameState.level - 1);
                lastLevel = gameState.level;
            }
            selfSource.Play();
        }
    }
}
