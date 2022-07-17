using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;


    private UnityEngine.Object destoction;

    public GameObject cristal;

    public Transform cristalPos;

    private Animator anim;

    void Start()
    {
        currentHealth = maxHealth;

        destoction = Resources.Load("Destoction");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        anim.SetTrigger("die");

        Debug.Log("Enemy died");

        GameObject destoctionRef = (GameObject)Instantiate(destoction);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Instantiate(cristal, cristalPos.position, transform.rotation);

        Destroy(gameObject);

        this.enabled = false;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
}
