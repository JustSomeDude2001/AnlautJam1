using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability
{
    public string key;

    public List <Vector2Int> effectOffsets;

    public Ability(int radius, int intensity) {
        effectOffsets = new List<Vector2Int>();
        int cellCount = intensity;
        
        for (int i = 1; i <= cellCount; i++) {
            int x, y;
            int newEffectValue = System.Math.Max(i / 2, 1);
            while(true) {
                x = Random.Range(0, radius + 1);
                y = Random.Range(0, radius + 1);

                if (x == 0 && y == 0) {
                    continue;
                }

                Vector2Int newOffset = new Vector2Int(x, y);

                if (!effectOffsets.Contains(newOffset)) {
                    
                    for (int ox = -1; ox <= +1; ox += 2) {
                        for (int oy = -1; oy <= +1; oy += 2) {
                            Vector2Int symOffset = newOffset;
                            symOffset.x *= ox;
                            symOffset.y *= oy;
                            effectOffsets.Add(symOffset);
                        }
                    }

                    break;
                }
            }
        }

        string candidates = "tyughjbnm";

        key = "";

        for (int i = 0; i < radius * 2; i++) {
            key += candidates[Random.Range(0, candidates.Length)];
        }
    }

    public Ability(int level) : this(level + 1, 
                                     level * System.Math.Max(level / 2, 1) + 1) { }
}
