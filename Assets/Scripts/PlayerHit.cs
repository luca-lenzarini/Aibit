using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy")) {
            //this.GetComponent<Knockback>().Knock(other);
            //GameObject.FindGameObjectsWithTag("Player").GetComponent<Knockback>().Knock(other);
            Debug.Log("tocou!");
        }
    }

    public void Knock(Collider2D other) {
        Rigidbody2D otherRb = other.GetComponent<Rigidbody2D>();
        otherRb.isKinematic = false;

        Vector2 difference = (otherRb.transform.position - transform.position).normalized * 7.5f;

        if(otherRb != null) {
            if(other.CompareTag("Enemy")) {
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
            yield return new WaitForSeconds(0.33f);
            otherRb.velocity = Vector2.zero;

            if(other.CompareTag("Enemy")) {
                EnemyMovement enemyController = other.GetComponent<EnemyMovement>();
                enemyController.canMove = true;

            }
            
        }
        otherRb.isKinematic = true;
        Debug.Log("PARA");
    }
}
