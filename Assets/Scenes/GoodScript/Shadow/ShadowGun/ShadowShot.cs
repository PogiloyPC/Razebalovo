using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowShot : MonoBehaviour
{
    public GameObject bullet_;

    public Transform shotDir;

    private float timeShot;
    public float startTime;


    private UnityEngine.Object destoction;

    public float offset;



    Transform player;
    public float stoppingDistance;



    private void Awake()
    {



    }




    void Start()
    {
        destoction = Resources.Load("IdleFire");

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        int choose = UnityEngine.Random.Range(7, 10);


        if (timeShot <= 0)
        {

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


            if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
            {

                Instantiate(bullet_, shotDir.position, transform.rotation);

                

                timeShot = startTime;
            }
        }
        else
        {
            timeShot -= Time.deltaTime;

        }




    }



}