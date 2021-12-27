using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInvoker : MonoBehaviour
{
    public GameObject attack;
    GameState gameState;
    void Start()
    {
        gameState = GameState.GetInstance();
    }

    public void InvokeAbility(Ability ability) {
        Vector3 center = transform.position;

        for (int i = 0; i < ability.effectOffsets.Count; i++) {
            Vector3 newPosition = center;
            newPosition.x += ability.effectOffsets[i].x;
            newPosition.y += ability.effectOffsets[i].y;

            Instantiate(attack, newPosition, Quaternion.identity);
        }
    }
}
