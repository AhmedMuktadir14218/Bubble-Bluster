using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    public int health; ///health help determine when an enemy should die 
    public int damage; ///damage help how much their death will hurt the Player
    public Transform targetTransform; ///It references the Player's transform

    void FixedUpdate () {
        if(targetTransform != null) {
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

/* MoveTowards()-> This is because the Enemy should move at the same speed all 
the time and not ease-in as it approaches the target*/



    public void TakeDamage(int damage) {
        health -= damage;
        if(health <= 0) {
            Destroy(this.gameObject);
        }
    }

    public void Attack(Player player) {
        player.health -= this.damage;
        Destroy(this.gameObject);
    }
    public void Initialize(Transform target, float moveSpeed, int health) {
        this.targetTransform = target;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

}
