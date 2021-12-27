using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GeneratesBoard : MonoBehaviour
{
    public GameObject border;
    void Start()
    {
        GameState curGame = GameState.GetInstance();

        int radius = curGame.boardRadius;

        for (int x = 0; x <= radius; x++) {
            for (int y = 0; y <= radius; y++) {
                if (Math.Abs(Math.Sqrt(y * y + x * x) - Math.Sqrt(radius * radius)) > 0.5) {
                    continue;
                }
                Instantiate(border, new Vector3(+x, +y, 0), Quaternion.identity);
                Instantiate(border, new Vector3(-x, -y, 0), Quaternion.identity);
                
                if (x != 0 && y != 0) {
                    Instantiate(border, new Vector3(+x, -y, 0), Quaternion.identity);
                    Instantiate(border, new Vector3(-x, +y, 0), Quaternion.identity);
                }
            }
        }
    }
}
