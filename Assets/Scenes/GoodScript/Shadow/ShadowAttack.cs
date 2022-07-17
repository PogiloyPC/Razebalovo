using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowAttack : MonoBehaviour
{
    [Header("Parametrs Attack")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private float range;
    [Header("Parametrs Collider")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;
    [Header("Parametrs Player")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldawnTimer = Mathf.Infinity;

    private EnemyPatrol enemyPatrol;
    private Patroler patroler;
    private ShadowMove shadow;
    private Health playerHealth;
    private Animator anim;

    public int maxHealth = 100;
    int currentHealth;


    


    public GameObject cristal;

    public Transform cristalPos;


    private UnityEngine.Object destoction;


    void Start()
    {
        currentHealth = maxHealth;

        destoction = Resources.Load("ShadowDestr");
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

        Destroy(gameObject);

        Instantiate(cristal, cristalPos.position, transform.rotation);

        this.enabled = false;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
        shadow = GetComponent<ShadowMove>();
    }


    private void Update()
    {

        cooldawnTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldawnTimer >= attackCooldown)
            {
                cooldawnTimer = 0;
                int choose = UnityEngine.Random.Range(1, 3);
                anim.Play("attack" + choose);
                anim.SetBool("moving", false);
            }
        }


        
        if (shadow != null)
            shadow.enabled = !PlayerInSight();


    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void onDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(boxCollider.bounds.center + transform.right * range * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));


    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
            playerHealth.TakeDamage(damage);
    }

}
