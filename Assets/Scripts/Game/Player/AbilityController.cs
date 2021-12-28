using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    GameState gameState;
    AbilityInvoker abilityInvoker;
    string currentString = "";
    void Start()
    {
        gameState = GameState.GetInstance();
        currentString = "";
        abilityInvoker = GetComponent<AbilityInvoker>();
    }

    bool needReGhost = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            currentString += 't';
            needReGhost = true;
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            currentString += 'y';
            needReGhost = true;
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            currentString += 'u';
            needReGhost = true;
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            currentString += 'g';
            needReGhost = true;
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            currentString += 'h';
            needReGhost = true;
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            currentString += 'j';
            needReGhost = true;
        }
        /*
        if (Input.GetKeyDown(KeyCode.B)) {
            currentString += 'b';
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            currentString += 'n';
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            currentString += 'm';
        }
        */

        if (needReGhost) {
            needReGhost = false;
            transform.DetachChildren();
            Ability currentAbility = gameState.GetAbility(currentString);
            if (currentAbility != null) {
                abilityInvoker.GhostAbility(currentAbility);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Ability currentAbility = gameState.GetAbility(currentString);
            if (currentAbility != null) {
                Debug.Log("Invoking ability with key " + currentString);
                
                abilityInvoker.InvokeAbility(currentAbility);
            }
            currentString = "";
            needReGhost = true;
        }
    }
}
