using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameState
{
    private static GameState instance;

    public List <Enemy> enemies;
    public List <Ability> abilities;

    public int boardRadius = 12;

    public int level = 1;

    public int xp = 0;
    public int xpToNextLevel = 10;

    private GameState() {
        instance = this;

        foreach (string file in Directory.EnumerateDirectories("Core", "Ability_*.xml")) {
            abilities.Add(XMLOp<Ability>.Deserialize(file));
        }

        foreach (string file in Directory.EnumerateDirectories("Core", "Enemy_*.xml")) {
            enemies.Add(XMLOp<Enemy>.Deserialize(file));
        }

        xp = 0;
        xpToNextLevel = 10;
        level = 1;
    }

    public bool levelUp() {
        if (xp < xpToNextLevel) {
            return false;
        } 

        xp -= xpToNextLevel;
        xpToNextLevel *= 2;
        level++;

        return true;
    }

    public static void LoadGame(string saveName) {
        instance = XMLOp<GameState>.Deserialize(saveName);
    }

    public static GameState GetInstance() {
        if (instance == null) {
            instance = new GameState();
        }
        return instance;
    }
}
