using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed;
    bool isFacingLeft;
    bool canMove = true;

    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sp;

    void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        Move();
        if (!canMove)
            rb.velocity = new Vector2(rb.velocity.x * 0, rb.velocity.y);           
    }

    void Move()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.deltaTime * horizontalSpeed, rb.velocity.y);
        anim.SetInteger("movement", (int)Input.GetAxisRaw("Horizontal"));

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            if (isFacingLeft)
                Flip();
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            if (!isFacingLeft)
                Flip();
        }
    }

    void Flip()
    {
        isFacingLeft = !isFacingLeft;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void StopMove() => canMove = false;
    void ActiveMove() => canMove = true;

    void OnEnable()
    {
        PlayerAttack.stopMovements += StopMove;
        PlayerAttack.activeMovements += ActiveMove;
    }

    void OnDisable()
    {
        PlayerAttack.stopMovements -= StopMove;
        PlayerAttack.activeMovements -= ActiveMove;
    }

}
