using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float visualField = 10f;
    public float attackRange = 0f;
    public float movementeSpeed = 5f;

    public Animator animator;

    public bool canMove = true;


    //public Animator animator;
    Transform target;
    
    // Start is called before the first frame update
    void Start() {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update() {
        
        float distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if(canMove && (distanceFromTarget <= visualField && distanceFromTarget > attackRange)) {
            FollowPlayer();
        } else {
            animator.SetFloat("Speed", 0);
        }
    }

    public void FollowPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementeSpeed * Time.deltaTime);

        Vector2 movement = new Vector2(target.position.x - transform.position.x, target.position.y - transform.position.y);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(movement != Vector2.zero) {
            animator.SetFloat("LastMoveX", movement.x);
            animator.SetFloat("LastMoveY", movement.y);
        }
    }
}
