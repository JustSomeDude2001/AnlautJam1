using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class GameState
{
    private static GameState instance;

    public int enemyCount = 0;
    public List <Ability> abilities;

    public int boardRadius = 12;

    public int level = 1;
    public int score = 0;
    public int killsThisTurn = 0;
    public static float difficulty = 1;

    public bool dead = false;

    [XmlIgnore]
    public List<TurnDependent> turnDependents;

    public Ability GetAbility(string key) {
        for (int i = 0; i < abilities.Count; i++) {
            if (abilities[i].key == key) {
                return abilities[i];
            }
        }
        return null;
    }

    private GameState() {
        Debug.Log("Created new game state");
        abilities = new List<Ability>();
        turnDependents = new List<TurnDependent>();

        /*foreach (string file in Directory.EnumerateFiles("Core", "Ability_*.xml", SearchOption.AllDirectories)) {
            abilities.Add(XMLOp<Ability>.Deserialize(file));
            Debug.Log("Deserialized Ability with key " + abilities[abilities.Count - 1].key);
        }*/

        level = 0;
    }

    public Vector3 GetRandomValidPos() {
        List <Vector3> validPositions = new List<Vector3>();
        for (int i = -boardRadius; i <= boardRadius; i++) {
            for (int j = -boardRadius; j <= boardRadius; j++) {
                Vector3 newPos = new Vector3(i, j, 0);
                if (Movable.IsFree(newPos)) {
                    validPositions.Add(newPos);
                }
            }
        }
        int index = Random.Range(0, validPositions.Count);
        return validPositions[index];
    }

    public void SpawnEnemy(Vector3 position, 
                           int radius, int intensity, int frequency) {
        if (Movable.IsFree(position)) {
            GameObject newEnemy = GameObject.Instantiate(Resources.Load<GameObject>("Enemy"), position, Quaternion.identity);
            InvokesAbilityRegularly invoker = newEnemy.GetComponent<InvokesAbilityRegularly>();
            invoker.ability = new Ability(radius, intensity);
            invoker.frequency = frequency;
        }
    }

    public void NextTurn() {
        if (enemyCount == 0) {
            SaveGame("LatestSave.xml");
            abilities.Add(new Ability(level));
            level++;
            for (int j = 0; j < level * level / 2 + 1; j++) {
                SpawnEnemy(GetRandomValidPos(),
                           level, level, 4);
            }
        }
        int i = 0;
        while (i < turnDependents.Count) {
            int lastChecked = turnDependents.Count;
            turnDependents[i].NextTurn();
            if (lastChecked == turnDependents.Count) {
                i++;
            }
        }
        score += killsThisTurn * 10;
        if (killsThisTurn > 1) {
            score += killsThisTurn * 5;
        }
        killsThisTurn = 0;
    }

    public static void LoadGame(string saveName) {
        instance = XMLOp<GameState>.Deserialize(saveName);
    }

    public static void SaveGame(string saveName) {

    }

    public static void NewGame() {
        instance = new GameState();
    }

    public static GameState GetInstance() {
        if (instance == null) {
            instance = new GameState();
        }
        return instance;
    }
}
