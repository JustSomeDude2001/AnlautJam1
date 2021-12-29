using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CyclesThroughScales : TurnDependent
{
    public List<Vector3> sizes;
    SpriteRenderer selfRenderer;
    int currentSize = 0;
    private void OnEnable() {
        selfRenderer = GetComponent<SpriteRenderer>();
    }
    public override void NextTurn()
    {
        if (currentSize >= sizes.Count) {
            currentSize = 0;
        }
        if (selfRenderer != null) 
            selfRenderer.size = sizes[currentSize];
        currentSize++;
    }
}
