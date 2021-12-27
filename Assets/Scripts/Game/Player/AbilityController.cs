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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            currentString += 't';
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            currentString += 'y';
        }
        if (Input.GetKeyDown(KeyCode.U)) {
            currentString += 'u';
        }
        if (Input.GetKeyDown(KeyCode.G)) {
            currentString += 'g';
        }
        if (Input.GetKeyDown(KeyCode.H)) {
            currentString += 'h';
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            currentString += 'j';
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            currentString += 'b';
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            currentString += 'n';
        }
        if (Input.GetKeyDown(KeyCode.M)) {
            currentString += 'm';
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            Ability currentAbility = gameState.GetAbility(currentString);
            Debug.Log("Invoking ability with key " + currentString);
            
            abilityInvoker.InvokeAbility(currentAbility);
            currentString = "";
        }
    }
}
