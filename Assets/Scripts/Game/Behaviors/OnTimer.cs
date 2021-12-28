using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTimer : MonoBehaviour
{
    public float lifespan = 1;
    private float currentTimeDelta = 0;
    
    void Update()
    {
        currentTimeDelta += Time.deltaTime;

        if (currentTimeDelta > lifespan) {
            Destroy(gameObject);
        }
    }
}
