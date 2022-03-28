using UnityEngine;

[RequireComponent(typeof(PlayerFlip))]
public class PlayerMovement : MonoBehaviour
{ 
    [Header("Movement Attributes")]

    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float maxHorizontalSpeed;

    [SerializeField] private float smoothTime;
    [SerializeField] private float currentVelocity;

    private bool canMove = true;

    private PlayerFlip playerFlip;
    private Rigidbody2D rb;
    private Animator anim;

    void Awake()
    {
        playerFlip = GetComponent<PlayerFlip>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
    }

    void FixedUpdate()
    {
        Move();

        if (!canMove)
            rb.velocity = new Vector2(rb.velocity.x * 0, rb.velocity.y);           
    }

    void Move()
    {
        horizontalSpeed = (Input.GetAxis("Horizontal") != 0f) ? Mathf.SmoothDamp(horizontalSpeed, maxHorizontalSpeed, ref currentVelocity, smoothTime) : Mathf.SmoothDamp(horizontalSpeed, 0, ref currentVelocity, 0.2f);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * horizontalSpeed, rb.velocity.y);
        
        anim.SetInteger("movement", (int)Input.GetAxisRaw("Horizontal"));

        playerFlip.OnFlip();
    }


    void OnEnable()
    {
        PlayerAttack.disableMovement += StopMove;
        PlayerAttack.enableMovements += ActiveMove;
    }

    void OnDisable()
    {
        PlayerAttack.disableMovement -= StopMove;
        PlayerAttack.enableMovements -= ActiveMove;
    }

    void StopMove() => canMove = false;
    void ActiveMove() => canMove = true;
}
