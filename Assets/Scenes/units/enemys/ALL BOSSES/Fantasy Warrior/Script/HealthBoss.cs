using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoss : MonoBehaviour
{
    
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    private Animator anim;


    public GameObject helthbar;


    private bool hit;

    private UnityEngine.Object destoction;
    void Start()
    {
        

        destoction = Resources.Load("Destoction");
    }


    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {

            anim.SetTrigger("hurt");
            
            
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                
                dead = true;

                GameObject destoctionRef = (GameObject)Instantiate(destoction);
                destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                Destroy(gameObject);
                Destroy(helthbar);
            }
        }
    }


    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }
}
