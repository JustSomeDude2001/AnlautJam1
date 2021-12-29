using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealsDamageOnContact : MonoBehaviour
{
    public string blacklistedTag;
    public int damage = 1;

    public void Update() {
        Collider2D other = Physics2D.OverlapPoint(new Vector2(transform.position.x, transform.position.y), 1);
        if (other != null) {
            //Debug.Log("Collided with enemy");
        } else {
            return;
        }
        if (other.tag == blacklistedTag) {
            return;
        }
        TakesDamage otherDamageable = other.gameObject.GetComponent<TakesDamage>();
        if (otherDamageable == null) {
            return;
        }
        otherDamageable.takeDamage(damage);
    }
}
