using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveDisplayer : TurnDependent
{
    TextMeshProUGUI selfText;
    int lastWave = -1;

    private void OnEnable() {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    public override void NextTurn()
    {
        if (gameState.level != lastWave) {
            selfText.text = "Wave " + gameState.level.ToString();
            lastWave = gameState.level;
        }
    }
}
