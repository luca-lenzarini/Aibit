using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 5;
    
    public void TakeDamage(int damage) {
        this.health = health - damage;

        if(health == 0) {
            gameObject.SetActive(false);
        }
    }
}
