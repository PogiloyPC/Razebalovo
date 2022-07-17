using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemi : MonoBehaviour
{

    

    public GameObject gObject;

    public Transform spawnPos;


    
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            GetComponent<Collider2D>().enabled = false;
            



            Instantiate(gObject, spawnPos.position, transform.rotation);


        }
    }


}
