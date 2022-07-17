using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;


    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !lockAttack)
        {
            Attack();

        }

        
    }

    private bool lockAttack = false;
    void AttackLock()
    {
        lockAttack = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void Attack()
    {

        lockAttack = true;
        Invoke("AttackLock", 0.5f);




        int choose = UnityEngine.Random.Range(1, 5);
        anim.Play("attack" + choose);


        GetComponent<Collider2D>().enabled = true;







    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthEnemy enemy = collision.GetComponent<HealthEnemy>();
        HealthBoss Benemy = collision.GetComponent<HealthBoss>();
        Patroler PatrolEnemy = collision.GetComponent<Patroler>();

        if (enemy != null)
        {
            enemy.TakeDamage(70);

           
        }
        if (Benemy != null)
        {
            Benemy.TakeDamage(70);

            
        }
       

    }

   
}
