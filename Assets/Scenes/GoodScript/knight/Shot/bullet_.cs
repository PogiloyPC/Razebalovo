using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_ : MonoBehaviour
{
    
    public float speedB;
    public float destroyTime;

    public int damage = 400;

    private UnityEngine.Object destoction;
    private UnityEngine.Object bul;

    void Start()
    {
        Invoke("Destroybullet_", destroyTime);

        destoction = Resources.Load("Gun");

        Invoke("bul", destroyTime);

        bul = Resources.Load("FireBoll");
    }

    
    void Update()
    {
 
            transform.Translate(Vector2.right * speedB * Time.deltaTime);

        GameObject destoctionRef = (GameObject)Instantiate(bul);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    void Destroybullet_()
    {
        Destroy(gameObject);
    }

    private bool hit;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        HealthBoss Benemy = collision.GetComponent<HealthBoss>();
        Patroler PatrolEnemy = collision.GetComponent<Patroler>();

        if (enemy != null)
        {
            enemy.TakeDamage(100);

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            //enemy.enabled = false;
            //hit = true;
        }
        if (Benemy != null)
        {
            Benemy.TakeDamage(100);

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        if (PatrolEnemy != null)
        {
            //enemy.enabled = false;
            //hit = true;

            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
        Destroy(gameObject);
       
    }

}
