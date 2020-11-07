using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float visualField = 10f;
    public float attackRange = 1f;
    public float movementeSpeed = 5f;


    //public Animator animator;
    Transform target;
    
    // Start is called before the first frame update
    void Start() {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update() {
        
        float distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if(distanceFromTarget <= visualField && distanceFromTarget > attackRange) {
            FollowPlayer();
        }
    }

    public void FollowPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, movementeSpeed * Time.deltaTime);

        // TODO: enemy animation
        // Define the animation it should be using to face the target
        //animator.SetFloat("Horizontal", target.position.x - transform.position.x);
        //animator.SetFloat("Vertical", target.position.y - transform.position.y);
    }
}
