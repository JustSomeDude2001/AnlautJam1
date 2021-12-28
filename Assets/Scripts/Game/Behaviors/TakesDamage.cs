using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakesDamage : MonoBehaviour
{

    public int health = 1;

    public void takeDamage(int amount = 1) {
        health -= amount;
        if (health <= 0) {
            Destroy(gameObject);
        }
    }
}
