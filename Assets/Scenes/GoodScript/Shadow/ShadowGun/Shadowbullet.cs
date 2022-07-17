using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowbullet : MonoBehaviour
{

    public float speedB;
    public float destroyTime;

    public int damage;

    Transform player;

    private Health playerHealth;

    private UnityEngine.Object destoction;
    private UnityEngine.Object bul;

    private Vector2 target;

    void Start()
    {
        Invoke("Destroybullet_", destroyTime);

        destoction = Resources.Load("Gun");

        Invoke("bul", destroyTime);

        bul = Resources.Load("FireBoll");

        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }


    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, 5 * Time.deltaTime);



        GameObject destoctionRef = (GameObject)Instantiate(bul);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

    }

    void Destroybullet_()
    {
        Destroy(gameObject);
    }
   

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(70);
            Destroy(gameObject);
            GameObject destoctionRef = (GameObject)Instantiate(destoction);
            destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }

}
