using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPatroler : MonoBehaviour
{
    bool movingRight;
    public float rayDistance;
    public float rayDistanceY;
    private Rigidbody2D body;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private float colliderDistance;
    [SerializeField] private LayerMask groundLayer;


    private Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if (movingRight == true)
        {
            RightJump();


        }
        else if (movingRight == false)
        {
            LeftJump();

        }
    }


    private void RightJump()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rayDistance * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * rayDistance, boxCollider.bounds.size.y * rayDistanceY, boxCollider.bounds.size.z),
            0, Vector2.left, 0, groundLayer);
        if (hit.collider != null)
        {
            body.velocity = Vector2.up * 3;
        }



    }
    private void LeftJump()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * rayDistance * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * rayDistance, boxCollider.bounds.size.y * rayDistanceY, boxCollider.bounds.size.z),
            0, Vector2.left, 0, groundLayer);

        if (hit.collider != null)
        {
            body.velocity = Vector2.up * 3;
        }

    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center + transform.right * rayDistance * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * rayDistance, boxCollider.bounds.size.y * rayDistanceY, boxCollider.bounds.size.z));

        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center + transform.right * rayDistance * colliderDistance,
         new Vector3(boxCollider.bounds.size.x * rayDistance, boxCollider.bounds.size.y * rayDistanceY, boxCollider.bounds.size.z));
    }

}