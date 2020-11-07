using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust = 4f;
    bool isColiding = false;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("hit");

        if(isColiding) return;

        isColiding = true;

        if(other.gameObject.CompareTag("Player")) { 
            this.Knock(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        isColiding = false;
    }

    private void Knock(Collider2D other) {
        Rigidbody2D player = other.GetComponent<Rigidbody2D>();

        if(player != null) {
            
            Vector2 difference = (player.transform.position - transform.position).normalized * thrust;
            
            PlayerController playerController = other.GetComponent<PlayerController>();

            if(playerController != null) {
                playerController.canMove = false;
                playerController.TakeDamage(5);
            }

            player.AddForce(difference, ForceMode2D.Impulse);

            StartCoroutine(KnockCo(other));
        }
    }

    private IEnumerator KnockCo(Collider2D other) {
        Rigidbody2D player = other.GetComponent<Rigidbody2D>();

        if(player != null) {
            yield return new WaitForSeconds(0.2f);
            player.velocity = Vector2.zero;

            PlayerController playerController = other.GetComponent<PlayerController>();
            playerController.canMove = true;
        }

        isColiding = false;
    }
}
