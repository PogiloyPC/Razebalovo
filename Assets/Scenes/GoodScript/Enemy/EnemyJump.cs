using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJump : MonoBehaviour
{
    bool movingRight;
    public float rayDistance;
    private Rigidbody2D body;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        //Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        if (movingRight == true)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.up, rayDistance);
            if (hit.collider.tag == "Ground")
            {
                body.velocity = Vector2.up * 6;
            }
        }
        else if (movingRight == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.up, rayDistance);
            if (hit.collider.tag == "Ground")
            {
                body.velocity = Vector2.up * 6;
            }
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDistance);
    }

}
