using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishWhenDead : MonoBehaviour
{
    public GameObject target;

    private void Update() {
        if (target == null) {
            gameObject.SetActive(false);
        }
    }
}
