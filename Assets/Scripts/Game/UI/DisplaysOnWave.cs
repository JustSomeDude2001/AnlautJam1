using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplaysOnWave : MonoBehaviour
{
    GameState gameState;
    TextMeshPro selfText;
    public string text;
    public int level;
    void Start()
    {
        gameState = GameState.GetInstance();
        selfText = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.level > level) {
            Destroy(gameObject);
        }
        if (gameState.level == level) {
            selfText.text = text;
        } else {
            selfText.text = "";
        }
    }
}
