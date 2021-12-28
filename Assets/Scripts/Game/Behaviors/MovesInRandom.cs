using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovesInRandom : TurnDependent
{
    Movable selfMover;

    private void OnEnable() {
        selfMover = GetComponent<Movable>();
    }

    public override void NextTurn()
    {
        List <Vector3> possiblePositions = new List<Vector3>();

        for (int i = -1; i <= +1; i++) {
            for (int j = -1; j <= +1; j++) {
                if (i == j && i == 0) {
                    continue;
                }
                possiblePositions.Add(new Vector3(i, j, 0) + transform.position);
            }
        }

        for (int i = 0; i < possiblePositions.Count; i++) {
            int newIndex = Random.Range(i, possiblePositions.Count);
            Vector3 temp = possiblePositions[i];
            possiblePositions[i] = possiblePositions[newIndex];
            possiblePositions[newIndex] = temp;
        }

        for (int i = 0; i < possiblePositions.Count; i++) {
            if (Movable.IsFree(possiblePositions[i])) {
                selfMover.MoveTo(possiblePositions[i]);
                return;
            }
        }
    }
}
