using System.Collections;
using UnityEngine;

namespace Player.Ground.Check
{
    public class GroundChecker : MonoBehaviour
    {     
        [SerializeField] private float groundCheckDistance;

        Rigidbody2D rb;

        void Awake() => rb = GetComponent<Rigidbody2D>();
        

        void Update() => GroundCheck();

        public bool GroundCheck()
        {
            RaycastHit2D ray = Physics2D.Raycast(rb.worldCenterOfMass, Vector2.down, groundCheckDistance, 1 << 8);
            Debug.DrawRay(rb.worldCenterOfMass, Vector2.down * groundCheckDistance, Color.red);

            return ray.collider != null;
        }
    }
}