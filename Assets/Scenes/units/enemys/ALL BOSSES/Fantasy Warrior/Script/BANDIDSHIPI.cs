using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BANDIDSHIPI : MonoBehaviour
{

    public GameObject spike;

    public Transform spikekDir;

    public void SpawnSpike()
    {
        Instantiate(spike, spikekDir.position, transform.rotation);
        //GetComponent<PlayerMove>().enabled = true;


    }
}
