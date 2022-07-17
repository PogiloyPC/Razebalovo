using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackVolna : MonoBehaviour
{
    public GameObject volna;

    public Transform attackDir;

    private float timeShot;
    public float startTime;

    [SerializeField] private Animator anim;


    


    private void Awake()
    {

        anim = GetComponent<Animator>();


    }




    void Start()
    {

    }


    void Update()
    {

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       

        if (timeShot <= 0)
        {
            if (Input.GetKeyDown(KeyCode.C))
            {

                anim.Play("VolnaAttack");

                GetComponent<PlayerMove>().enabled = false;

                timeShot = startTime;
            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }




    }


    public void SpawnVolna()
    {
        Instantiate(volna, attackDir.position, transform.rotation);
        GetComponent<PlayerMove>().enabled = true;

        
    }
}
