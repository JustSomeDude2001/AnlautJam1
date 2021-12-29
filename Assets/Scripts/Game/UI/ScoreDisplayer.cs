using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayer : TurnDependent
{
    TextMeshProUGUI selfText;

    private void OnEnable() {
        selfText = GetComponent<TextMeshProUGUI>();
    }

    public override void NextTurn()
    {
        string result = "";
        result += "Score: " + gameState.score.ToString() + '\n';
        if (gameState.killsThisTurn != 0)
            result += "Kills: " + (gameState.killsThisTurn * 10).ToString() + '\n';
        if (gameState.killsThisTurn > 1)
            result += "Combo bonus: " + (gameState.killsThisTurn * 5).ToString() + '\n';
        selfText.text = result;
    }
}
