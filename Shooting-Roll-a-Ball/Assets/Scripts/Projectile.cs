using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public int damage;

    Vector3 shootDirection; ///ShootDirection vector determines where the Projectile will go.

/* 
1. The Projectile moves differently than everything else in this game. It doesn't have a target, or some force applied to it over time; instead, it moves in a predetermined direction for its entire lifecycle.

2. Here you set the starting position and direction of the Prefab. This Ray argument seems pretty mysterious, but you'll soon learn how it's calculated.

3. If a projectile collides with an enemy, it calls TakeDamage() and destroys itself.
*/

    // 1
    void FixedUpdate () {
        this.transform.Translate(shootDirection * speed, Space.World);
    }

    // 2
    public void FireProjectile(Ray shootRay) {
        this.shootDirection = shootRay.direction;
        this.transform.position = shootRay.origin;
    }

    // 3
    void OnCollisionEnter (Collision col) {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if(enemy) {
            enemy.TakeDamage(damage);
        }
        Destroy(this.gameObject);
    }

    void rotateInShootDirection() {
        Vector3 newRotation = Vector3.RotateTowards(transform.forward, shootDirection, 0.01f, 0.0f);
        transform.rotation = Quaternion.LookRotation(newRotation);
    }
    
}
