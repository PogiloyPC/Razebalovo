using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPEAR : MonoBehaviour
{ 
public float speedB;
public float destroyTime;

public int damage;

Transform player;

private Health playerHealth;





void Start()
{
    

    player = GameObject.FindGameObjectWithTag("Player").transform;

    
}


void Update()
{

    transform.Translate(Vector2.right * speedB * Time.deltaTime);





}

void Destroybullet_()
{
    Destroy(gameObject);
}




private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.tag == "Player")
    {
        collision.GetComponent<Health>().TakeDamage(40);
        Destroy(gameObject);
        
    }
}

}
