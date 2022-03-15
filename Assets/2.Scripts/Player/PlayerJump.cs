﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GroundChecker))]
public class PlayerJump : MonoBehaviour
{
    public delegate bool OnGround();
    public static event OnGround onGround;

    [SerializeField] private float jumpForce;

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
        onGround.Invoke();
    }

    void Update() => anim.SetFloat("JumpAxis", rb.velocity.y);

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if((onGround.Invoke()))
                rb.velocity = new Vector3(rb.velocity.x, Time.deltaTime * jumpForce);
        }

        anim.SetBool("Jumping", !onGround.Invoke());
    }
}
