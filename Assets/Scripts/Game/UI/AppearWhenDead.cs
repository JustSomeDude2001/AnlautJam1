using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearWhenDead : MonoBehaviour
{
    public GameObject target;
    RectTransform selfTransform;
    public Vector3 newPosition;

    private void Start() {
        selfTransform = GetComponent<RectTransform>();
    }

    private void Update() {
        if (target == null) {
            selfTransform.anchoredPosition3D = newPosition;
        }
    }
}
