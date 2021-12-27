using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplaysRandomAbility : MonoBehaviour
{
    public int targetLevel = 5;
    public GameObject dummy;
    List <GameObject> toRem;
    void DisplayAbility(int level) {
        Ability newAbility = new Ability(level);

        if (toRem == null) {
            toRem = new List<GameObject>();
        }
        for (int i = 0; i < newAbility.effectOffsets.Count; i++) {
            int x = newAbility.effectOffsets[i].x;
            int y = newAbility.effectOffsets[i].y;
            GameObject tmp = Instantiate(dummy, new Vector3(x, y, 0), Quaternion.identity);
            toRem.Add(tmp);
        }
    }

    void ClearDummies() {
        if (toRem == null) {
            return;
        }
        for (int i = 0; i < toRem.Count; i++) {
            Destroy(toRem[i]);
        }
    }

    private void OnMouseDown() {
        ClearDummies();
        DisplayAbility(targetLevel);
    }
}
