using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private Vector2 direction;
    private Animator animator;
    private RaycastHit2D hit;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        if(direction.x > 0)
            transform.localScale = Vector2.one;
        else if(direction.x < 0)
            transform.localScale = new Vector2(-1,1);
        if (direction.x != 0 || direction.y != 0)
            animator.Play("PlayerMove");
        else
            animator.Play("PlayerIdle");

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, direction.y), Mathf.Abs(direction.y * 5 * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if(hit.collider==null)
        {
            transform.Translate(0,direction.y * 5* Time.deltaTime,0);

        }
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(direction.x, 0), Mathf.Abs(direction.x * 5 * Time.deltaTime), LayerMask.GetMask("Actor", "Blocking"));

        if (hit.collider == null)
        {
            transform.Translate(direction.x * 5 * Time.deltaTime, 0,0);

        }
    }
}