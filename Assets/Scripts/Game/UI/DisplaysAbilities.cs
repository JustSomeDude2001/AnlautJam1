using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysAbilities : TurnDependent
{
    TextMeshProUGUI selfText;
    void OnEnable()
    {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public override void NextTurn()
    {
        string res = "Spells:\n";
        for (int i = 0; i < gameState.abilities.Count; i++) {
            res += gameState.abilities[i].key;
            res += '\n';
        }
        selfText.text = res;
    }
}
