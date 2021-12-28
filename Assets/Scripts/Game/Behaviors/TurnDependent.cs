using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurnDependent : MonoBehaviour
{
    public abstract void NextTurn();

    protected GameState gameState;
    private void Start() {
        gameState = GameState.GetInstance();
        gameState.turnDependents.Add(this);
    }

    private void OnDestroy() {
        if (gameState.turnDependents.Contains(this))
            gameState.turnDependents.Remove(this);
    }
}
