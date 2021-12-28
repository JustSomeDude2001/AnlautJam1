using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishesIfNoParent : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null) {
            Destroy(gameObject);
        }
    }
}
