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

    public Ability GetAbility(string key) {
        for (int i = 0; i < abilities.Count; i++) {
            if (abilities[i].key == key) {
                return abilities[i];
            }
        }
        return new Ability(0, 0);
    }

    private GameState() {
        Debug.Log("Created new game state");
        instance = this;
        abilities = new List<Ability>();
        enemies = new List<Enemy>();

        foreach (string file in Directory.EnumerateFiles("Core", "Ability_*.xml", SearchOption.AllDirectories)) {
            abilities.Add(XMLOp<Ability>.Deserialize(file));
            Debug.Log("Deserialized Ability with key " + abilities[abilities.Count - 1].key);
        }

        foreach (string file in Directory.EnumerateFiles("Core", "Enemy_*.xml", SearchOption.AllDirectories)) {
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
