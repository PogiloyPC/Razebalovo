using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Volna : MonoBehaviour
{

    public float speedB;
    public float destroyTime;

    public int damage = 400;

    private UnityEngine.Object destoction;
    private UnityEngine.Object bul;

    void Start()
    {
        Invoke("Destroyvolna", destroyTime);


        destoction = Resources.Load("EXsplosion");



        bul = Resources.Load("volna");
    }
    

    void Update()
    {

        GameObject destoctionRef = (GameObject)Instantiate(bul);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);


        transform.Translate(Vector2.right * speedB * Time.deltaTime);
       

    }

    void Destroyvolna()
    {
        Destroy(gameObject);

        GameObject destoctionRef = (GameObject)Instantiate(destoction);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();

        ShadowAttack Senemy = collision.GetComponent<ShadowAttack>();
        if (enemy != null)
        {
            enemy.TakeDamage(140);

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }
        if (Senemy != null)
        {
            Senemy.TakeDamage(140);

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        }

    }

}