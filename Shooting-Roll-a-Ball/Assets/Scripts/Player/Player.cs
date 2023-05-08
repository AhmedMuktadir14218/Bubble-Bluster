using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

///This script will react to collisions and keep track of the Player's health.
public class Player : MonoBehaviour
{
    public int health = 3;
    public event Action<Player> onPlayerDeath;

    void collidedWithEnemy(Enemy enemy) {
        enemy.Attack(this);
        if(health <= 0) {
            if(onPlayerDeath != null) {
                onPlayerDeath(this);
            }
        }
    }

    void OnCollisionEnter (Collision col) ///OnCollisionEnter() triggers when two rigidbodies with colliders touch.
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
        if(enemy) {
            collidedWithEnemy(enemy);
        }
    }
    
}
