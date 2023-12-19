using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
        
    public Rigidbody2D rb { get; set; }
    private int Speed = 5;
    public Vector2 direction { get; set; }
    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

   

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * Speed * Time.fixedDeltaTime);
        if (direction.x > 0)
            rb.transform.localScale = Vector2.one;

        else if (direction.x < 0)
            rb.transform.localScale = new Vector2(-1, 1);
        if (direction.x != 0 || direction.y != 0)
            animator.Play("PlayerMove");
        else
            animator.Play("PlayerIdle");
    }
   


}
