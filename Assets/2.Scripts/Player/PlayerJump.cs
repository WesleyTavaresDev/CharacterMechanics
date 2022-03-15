using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerJump : MonoBehaviour
{
    public delegate bool OnJump();
    public static event OnJump jump;

    [SerializeField] private float jumpForce;
    bool isJumping;

    Rigidbody2D rb;
    Animator anim;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Jump();
        jump.Invoke();
    }

    void Update() => anim.SetFloat("JumpAxis", rb.velocity.y);

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if((jump.Invoke()))
                rb.velocity = new Vector3(rb.velocity.x, Time.deltaTime * jumpForce);
        }

        anim.SetBool("Jumping", !jump.Invoke());
    }
}
