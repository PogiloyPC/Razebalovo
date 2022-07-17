using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHOTSPEAR : MonoBehaviour
{

    public GameObject spear;

    public Transform spearDir;

    public void SpawnSpear()
    {
        Instantiate(spear, spearDir.position, transform.rotation);
        //GetComponent<PlayerMove>().enabled = true;


    }
}
