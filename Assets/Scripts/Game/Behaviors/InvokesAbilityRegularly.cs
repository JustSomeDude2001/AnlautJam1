using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InvokesAbilityRegularly : TurnDependent
{
    public int frequency = 4;
    public Ability ability;
    int turnsSinceAbility = 0;
    Movable selfMover;
    AbilityInvoker selfInvoker;
    private void OnEnable() {
        selfMover = GetComponent<Movable>();
        selfInvoker = GetComponent<AbilityInvoker>();
        ability = new Ability(4, 2);
    }

    public override void NextTurn()
    {
        turnsSinceAbility++;
        if (turnsSinceAbility == frequency - 1) {
            selfInvoker.GhostAbility(ability);
            selfMover.FreezeTurns = 1;
        }
        if (turnsSinceAbility == frequency) {
            transform.DetachChildren();
            selfInvoker.InvokeAbility(ability);
            turnsSinceAbility = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
