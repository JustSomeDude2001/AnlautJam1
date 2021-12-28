using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrderer : MonoBehaviour
{
    public float beatInterval = 1;
    private float currentTimeDelta = 0;

    AudioSource selfSource;
    GameState gameState;
    void Start()
    {
        gameState = GameState.GetInstance();
        selfSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {

        currentTimeDelta += Time.fixedDeltaTime;
        if (beatInterval <= currentTimeDelta) {
            currentTimeDelta -= beatInterval;
            gameState.NextTurn();
        }
    }
}
