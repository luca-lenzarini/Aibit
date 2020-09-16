using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float visualField = 10f;
    public float attackRange = 1f;
    public float movementeSpeed = 5f;
    public Animator animator;
    Transform target;
    
    // Start is called before the first frame update
    void Start() {
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update() {
        
        float distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if(distanceFromTarget <= attackRange) {
            //do attack
        }else if(distanceFromTarget <= visualField) {
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

    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player") {
            Debug.Log("tocou");
        }    
    }
}
