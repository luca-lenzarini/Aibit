using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust = 4f;
    bool isColiding = false;

    private void OnTriggerEnter2D(Collider2D other) {

        if(isColiding) return;

        isColiding = true;

        if(other.gameObject.CompareTag("Player")) { 
            this.Knock(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isColiding = false;
    }

    public void Knock(Collider2D other) {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        otherRb.isKinematic = false;

        Vector2 difference = (otherRb.transform.position - transform.position).normalized * thrust;

        if(otherRb != null) {
            // se quem vai ser empurrado for o player
            if(other.CompareTag("Player")) {
                PlayerController playerController = other.GetComponent<PlayerController>();

                if(playerController != null) {
                    playerController.canMove = false;
                    playerController.TakeDamage(5);
                }
            // se quem vai ser empurrado for o enemy
            } else if(other.CompareTag("Enemy")) {
                EnemyMovement enemyController = other.GetComponent<EnemyMovement>();
                enemyController.canMove = false;
            }    

            otherRb.AddForce(difference, ForceMode2D.Impulse);

            StartCoroutine(KnockCo(other));
        }
    }

    private IEnumerator KnockCo(Collider2D other) {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();

        if(otherRb != null) {
            yield return new WaitForSeconds(0.2f);
            otherRb.velocity = Vector2.zero;

            if(other.CompareTag("Player")) {
                PlayerController playerController = other.GetComponent<PlayerController>();
                playerController.canMove = true;
            } else {
                EnemyMovement enemyController = other.GetComponent<EnemyMovement>();
                enemyController.canMove = true;
            }
        }
        otherRb.isKinematic = true;
        isColiding = false;
    }
}
