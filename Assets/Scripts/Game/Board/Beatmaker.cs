using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Beatmaker : MonoBehaviour
{
    public float beatInterval = 1;
    private float currentTimeDelta = 0;

    int lastLevel;

    AudioSource selfSource;
    GameState gameState;
    BoomBox selfBoombox;
    void Start()
    {
        gameState = GameState.GetInstance();
        selfSource = GetComponent<AudioSource>();
        selfBoombox = GetComponent<BoomBox>();
        lastLevel = -1;
    }

    void FixedUpdate()
    {
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
