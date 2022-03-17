using UnityEngine;

[RequireComponent(typeof(PlayerFlip))]
public class PlayerMovement : MonoBehaviour
{ 
    [Header("Movement Attributes")]
    [SerializeField] private float horizontalSpeed;
    bool canMove = true;

    PlayerFlip playerFlip;
    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        playerFlip = GetComponent<PlayerFlip>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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

        playerFlip.OnFlip();
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
