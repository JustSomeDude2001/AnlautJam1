using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemy : MonoBehaviour
{
    GameState gameState;
    void Start()
    {
        gameState = GameState.GetInstance();
        gameState.enemyCount++;
    }

    private void OnDestroy() {
        gameState.enemyCount--;
    }

}
