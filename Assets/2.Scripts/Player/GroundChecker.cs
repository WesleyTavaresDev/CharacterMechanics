﻿using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{     
    [SerializeField] private float groundCheckDistance;

    Rigidbody2D rb;

    public bool GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rb.worldCenterOfMass, Vector2.down, groundCheckDistance, 1 << 8);
        Debug.DrawRay(rb.worldCenterOfMass, Vector2.down * groundCheckDistance, Color.red);

        return ray.collider != null;
    }
    
    void OnEnable() => PlayerJump.onGround += GroundCheck;
    void OnDisable() => PlayerJump.onGround -= GroundCheck;

    void Awake() => rb = GetComponent<Rigidbody2D>();
    void Update() => GroundCheck();
}
