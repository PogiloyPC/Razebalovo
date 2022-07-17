using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChets : MonoBehaviour
{

    private Rigidbody2D body;

    public GameObject gObject;

    public Transform spawnPos;


    void Start()
    {
        
        body = GetComponent<Rigidbody2D>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            GetComponent<Collider2D>().enabled = false;
            GetComponent<Animator>().SetTrigger("open");



            Instantiate(gObject, spawnPos.position, transform.rotation);
            

        }
    }

    
}
