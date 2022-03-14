using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float groundCheckDistance;
    bool isJumping;
    
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Jump();
        GroundCheck();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(!isJumping) 
                rb.velocity = new Vector3(rb.velocity.x, Time.deltaTime * jumpForce);
        }
    }

    void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rb.worldCenterOfMass, Vector2.down, groundCheckDistance, 1 << 8);
        Debug.DrawRay(rb.worldCenterOfMass, Vector2.down * groundCheckDistance, Color.red);
        
        if(ray.collider != null)
            isJumping = false;
        else
            isJumping = true;
    }
}
