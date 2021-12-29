using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopsGameOnDeath : MonoBehaviour
{
    GameState gameState;
    void Start()
    {
        gameState = GameState.GetInstance();
    }

    private void OnDestroy() {
        gameState.dead = true;
    }
}
