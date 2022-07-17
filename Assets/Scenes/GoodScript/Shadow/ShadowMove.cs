using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowMove : MonoBehaviour
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


    private UnityEngine.Object destoction;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        destoction = Resources.Load("ShadowIdle");
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

        GameObject destoctionRef = (GameObject)Instantiate(destoction);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


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


        transform.position = Vector2.MoveTowards(transform.position, player.position, 2 * speed * Time.deltaTime);
        

        

        anim.SetBool("moving", true);
    }

    void GoBack()
    {


        transform.position = Vector2.MoveTowards(transform.position, point.position, speed * Time.deltaTime);
        

        anim.SetBool("moving", true);
    }


}
