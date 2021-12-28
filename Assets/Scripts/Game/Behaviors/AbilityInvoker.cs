using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityInvoker : MonoBehaviour
{
    public string blacklistedTag;
    public GameObject attack;
    public GameObject ghost;
    GameState gameState;
    void Start()
    {
        gameState = GameState.GetInstance();
    }

    public void GhostAbility(Ability ability) {

        for (int i = 0; i < ability.effectOffsets.Count; i++) {
            Vector3 newPosition = transform.position;
            newPosition.x += ability.effectOffsets[i].x;
            newPosition.y += ability.effectOffsets[i].y;

            GameObject newGameObject = Instantiate(ghost, newPosition, Quaternion.identity);
            newGameObject.transform.parent = transform;
        }
    }

    public void InvokeAbility(Ability ability) {
        Vector3 center = transform.position;

        for (int i = 0; i < ability.effectOffsets.Count; i++) {
            Vector3 newPosition = center;
            newPosition.x += ability.effectOffsets[i].x;
            newPosition.y += ability.effectOffsets[i].y;

            GameObject newAttack = Instantiate(attack, newPosition, Quaternion.identity);
            DealsDamageOnContact attacker = newAttack.GetComponent<DealsDamageOnContact>();
            attacker.blacklistedTag = blacklistedTag;
        }
    }
}
