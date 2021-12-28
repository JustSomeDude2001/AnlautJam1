using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    static GameState gameState;
    public int FreezeTurns = 0;
    private void Start() {
        gameState = GameState.GetInstance();
    }

    public static bool IsFree(Vector3 newPos) {
        if (gameState.boardRadius - newPos.magnitude < 0.5) {
            return false;
        }
        Collider2D other = Physics2D.OverlapPoint(new Vector2(newPos.x, newPos.y));
        if (other != null) {
            return false;
        }
        return true;
    }

    public void MoveTo(Vector3 newPos) {
        if (FreezeTurns > 0) {
            FreezeTurns--;
            return;
        }
        if (IsFree(newPos))
            transform.position = newPos;
    }
}
