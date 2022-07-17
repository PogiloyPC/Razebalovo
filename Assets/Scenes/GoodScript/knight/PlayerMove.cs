using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float Lspeed;
    [SerializeField] private float Fspeed;
    [SerializeField] private float speed;
    [SerializeField] private float Fjump;
    [SerializeField] private float RollImpuls;




    


    public static Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    

   

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Grib vrag = GetComponent<Grib>();
      
    }

    private void Update()

    {
        if (Input.GetKeyDown(KeyCode.Space) && !lockRoll && grounded)
            Roll();

        if (Input.GetKeyDown(KeyCode.W) && grounded)
            Jump();

       


        if (Input.GetKey(KeyCode.S))
        {

            Crouch();
         
        }    


      
       

        anim.SetBool("grounded", grounded);
        anim.SetBool("wall", grounded);


        float walk = Input.GetAxis("Horizontal");

            body.velocity = new Vector2(walk * speed, body.velocity.y);



            if (walk > 0.01f)
                transform.localScale = Vector3.one;
            else if (walk < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);

            anim.SetBool("walk", walk != 0);

     

        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.LeftShift))
            Run();


        if (Input.GetButton("Horizontal") && Input.GetKey(KeyCode.S) )
            CrouchWalk();

    }

   



    private void Run()
    {
        float run = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(run * Fspeed, body.velocity.y);
        


        if (run > 0.01f)
            transform.localScale = Vector3.one;
        else if (run < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetTrigger("Run");

    }




   

   
    

    




    



    private void Crouch()
    {
        

        anim.SetBool("crouchBool", true);
    }

    private void CrouchWalk()
    {
        float Crouchwalk = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(Crouchwalk * Lspeed, body.velocity.y);


        if (Crouchwalk > 0.01f)
            transform.localScale = Vector3.one;
        else if (Crouchwalk < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);


        anim.SetTrigger("crouchwalk");  
    }


    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, Fjump);
        anim.SetTrigger("jump");
        grounded = false;
        
    }
   
    private bool wall;

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
       


    }

    

    private bool hit;

    private void Roll()
    {
        lockRoll = true;
        Invoke("RollLock", 0.5f);

        anim.Play("roll");


        //GetComponent<Health>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        hit = true;
         
        this.enabled = false;


        body.velocity = new Vector2(0, 0);

       if (body.transform.localScale.x < 0) { body.AddForce(Vector2.left * RollImpuls); body.velocity = Vector2.up * 1; }
       else { body.AddForce(Vector2.right * RollImpuls); body.velocity = Vector2.up * 1; }
    }




    private bool lockRoll = false;
    void RollLock()
    {
        lockRoll = false;
    }



    public void RespawnRoll()
    {
        hit = false;

        
        //GetComponent<Health>().enabled = true;
        GetComponent<Collider2D>().enabled = true;

        this.enabled = true;
    }



}
