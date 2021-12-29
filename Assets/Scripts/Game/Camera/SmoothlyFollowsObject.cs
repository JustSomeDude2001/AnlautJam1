using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothlyFollowsObject : MonoBehaviour
{
    public GameObject target;
    public float approachRate;

    // Update is called once per frame
    void Update()
    {
        if (target == null) {
            return;
        }
        Vector3 delta = target.transform.position - transform.position;
        delta *= approachRate * Time.deltaTime;
        delta.z = 0;
        Vector3 newPos = transform.position + delta;
        transform.position = newPos;        
    }
}
