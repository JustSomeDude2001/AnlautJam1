using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySetter : MonoBehaviour
{
    Button selfButton;
    public TextMeshProUGUI selfText;

    public List<float> difficulties;

    public List<ColorBlock> colors;

    public List<string> names;

    int currentDifficulty = 0;

    private void Start() {
        selfButton = GetComponent<Button>();

        for (int i = 0; i < difficulties.Count; i++) {
            if (System.Math.Abs(difficulties[i] - GameState.difficulty) < 0.001) {
                selfButton.colors = colors[i];
                selfText.text = names[i];
                GameState.difficulty = difficulties[i];
                currentDifficulty = i;
                break;
            }
        }
    }

    public void changeDifficulty() {
        currentDifficulty++;
        if (currentDifficulty >= difficulties.Count) {
            currentDifficulty = 0;
        }

        int i = currentDifficulty;
        selfButton.colors = colors[i];
        selfText.text = names[i];
        GameState.difficulty = difficulties[i];
    }

    public void setHighscore() {
        int current = getHighscore();
        PlayerPrefs.SetInt(names[currentDifficulty], System.Math.Max(GameState.GetInstance().score, current));
        PlayerPrefs.Save();
    }

    public int getHighscore() {
        return PlayerPrefs.GetInt(names[currentDifficulty], 0);
    }
}
