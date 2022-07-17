using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHEBoss : MonoBehaviour
{

    public GameObject backGround;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {

            GetComponent<Collider2D>().enabled = false;



            backGround.SetActive(!backGround.activeSelf);

            



        }
    }
}
