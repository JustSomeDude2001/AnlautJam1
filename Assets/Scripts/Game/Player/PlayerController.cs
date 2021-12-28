using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameState gameState;
    Movable selfMover;
    private void Start() {
        gameState = GameState.GetInstance();
        selfMover = GetComponent<Movable>();
    }
    private void Update() {
        Vector3 newPos = transform.position;
        if (Input.GetKeyDown(KeyCode.W)) {
            newPos.y++;
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            newPos.y--;
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            newPos.x--;
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            newPos.x++;
        }
        selfMover.MoveTo(newPos);
    }
}
