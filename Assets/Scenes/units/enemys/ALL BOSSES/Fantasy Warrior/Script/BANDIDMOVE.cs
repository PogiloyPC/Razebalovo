using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BANDIDMOVE : MonoBehaviour
{

    public float speed;
    public int positionOfPatrol;

    public Transform point;

    bool movingRight;


    Transform player;
    public float stoppingDistance;

    private Animator anim;

    bool chill = false;
    bool angry = false;
    bool goBack = false;


    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }




    void Update()
    {
        if (Vector2.Distance(transform.position, point.position) < positionOfPatrol && angry == false)
        {
            chill = true;
        }
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            angry = true;
            chill = false;
            goBack = false;
        }
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            goBack = true;
            angry = false;
        }


        if (chill == true)
        {
            Chill();
        }
        else if (angry == true)
        {
            Angry();
        }
        else if (goBack == true)
        {
            GoBack();
        }

        


    }



    void Chill()
    {



        if (transform.position.x > point.position.x + positionOfPatrol)
        {
            movingRight = false;
        }
        else if (transform.position.x < point.position.x - positionOfPatrol)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x > 0.01f)
                transform.localScale = Vector3.one;
            else if (transform.position.x < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);

            if (transform.position.x < 0.01f)
                transform.localScale = Vector3.one;
            else if (transform.position.x > -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        }


        anim.SetBool("moving", true);
    }

    void Angry()
    {


        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);




        anim.SetBool("moving", true);
    }

    void GoBack()
    {


        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);


        anim.SetBool("moving", true);
    }


}
