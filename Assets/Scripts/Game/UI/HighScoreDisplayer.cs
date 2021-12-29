using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplayer : MonoBehaviour
{
    public DifficultySetter difficultySetter;
    TextMeshProUGUI selfText;
    GameState gameState;

    bool updatedHighscore = false;

    private void Start() {
        gameState = GameState.GetInstance();
        selfText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!updatedHighscore && gameState.dead) {
            updatedHighscore = true;
            difficultySetter.setHighscore();
        }
        
        if (updatedHighscore && !gameState.dead) {
            updatedHighscore = false;
        }
        
        selfText.text = "Highscore " + difficultySetter.getHighscore().ToString();
    }
}
