using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody2D rigidbody;
    public Animator animator;
    Vector2 movement;

    // Update is called once per frame
    void Update() {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate() {
        // 
        rigidbody.MovePosition(rigidbody.position + movement.normalized * movementSpeed * Time.fixedDeltaTime);
    }
}
