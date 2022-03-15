using System.Collections;
using UnityEngine;
using System;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] AnimationClip attackClip;
   
    private const float ANIMATION_OFFSET = 0.2f;
    private Animator anim;

    void Start() => anim = GetComponent<Animator>();
  
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Attack());      
    }

    IEnumerator Attack()
    {
        anim.SetBool("Attacking", true);
        yield return new WaitForSeconds(attackClip.length + ANIMATION_OFFSET);
        anim.SetBool("Attacking", false);
    }

   
}
