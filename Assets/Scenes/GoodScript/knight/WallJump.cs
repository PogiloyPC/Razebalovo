using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    private bool wall = false;
    [SerializeField] private Animator anim;
    private bool grounded;
    [SerializeField] private float Fjump;
    [SerializeField] private Rigidbody2D body;
    private void Awake()
    {

        


    }
    private void Update()
    {
        anim.SetBool("wall", grounded);
        if (Input.GetKeyDown(KeyCode.W) && wall)
        {
            wallJump();

        }


    }

    private void wallJump()
    {
        body.velocity = new Vector2(body.velocity.x, Fjump);
        anim.SetTrigger("jump");
        wall = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {

            anim.SetTrigger("walltacked");

            
            wall = true;
        }
    }
}
