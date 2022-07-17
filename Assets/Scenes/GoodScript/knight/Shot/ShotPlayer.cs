using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotPlayer : MonoBehaviour
{
    public GameObject bullet_;

    public Transform shotDir;

    private float timeShot;
    public float startTime;

   
    private UnityEngine.Object destoction;

    public float offset;



    



    private void Awake()
    {

  

    }




    void Start()
    {
        destoction = Resources.Load("IdleFire");
    }

    
    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);
        
        if (timeShot <= 0)
        {

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


            if (Input.GetButtonDown("Fire2"))
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
