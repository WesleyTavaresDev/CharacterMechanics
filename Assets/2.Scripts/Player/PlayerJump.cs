using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Ground.Check;

[RequireComponent(typeof(GroundChecker))]
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    bool isJumping;

    GroundChecker groundChecker;
    Rigidbody2D rb;
    Animator anim;
    
    void Awake()
    {
        groundChecker = GetComponent<GroundChecker>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Jump();
        groundChecker.GroundCheck();
    }

    void Update() => anim.SetFloat("JumpAxis", rb.velocity.y);

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(groundChecker.GroundCheck())
                rb.velocity = new Vector3(rb.velocity.x, Time.deltaTime * jumpForce);
        }
        anim.SetBool("Jumping", !groundChecker.GroundCheck());
    }
}
