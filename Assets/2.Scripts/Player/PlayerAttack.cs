using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public delegate void StopMovements();

    public static event StopMovements stopMovements;
    public static event StopMovements activeMovements;

   [SerializeField] AnimationClip attackClip;
   
    private const float ANIMATION_OFFSET = 0.2f;
    private Animator anim;

    private void Awake() => anim = GetComponent<Animator>();
  
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        stopMovements?.Invoke();
        anim.SetBool("Attacking", true);
        
        yield return new WaitForSeconds(attackClip.length + ANIMATION_OFFSET);

        activeMovements?.Invoke();
        anim.SetBool("Attacking", false);
    } 
}
