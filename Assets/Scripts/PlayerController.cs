using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 10f;
    public Rigidbody2D rb;
    public Animator animator;
    public bool canMove = true;
    public int health = 100;

    Vector2 movement;

    // Update is called once per frame
    void Update() {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(Input.GetButtonDown("attack")) {
            StartCoroutine(AttackCo());
        }
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private IEnumerator AttackCo() {
        animator.SetBool("attacking", true);
        canMove = false;
        yield return null;
        animator.SetBool("attacking", false);
        yield return new WaitForSeconds(.33f);
        canMove = true;
    }

    void FixedUpdate() {
        if(canMove && (movement.x != 0 || movement.y != 0)) {
            rb.MovePosition(rb.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(int damage) {

        if(health > 0) {
            health = health - damage;
            HealthController healthController = FindObjectOfType<HealthController>();

            healthController.playerCurrentHealth = this.health;

            healthController.updateHearts();
        } else {
            // kill player
            gameObject.SetActive(false);
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }
}
