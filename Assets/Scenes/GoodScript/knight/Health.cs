using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private bool dead;
    private Animator anim;

    public GameObject shadow;

    public Transform shadowPos;

    private bool hit;

    private UnityEngine.Object destoction;

    void Start()
    {
        destoction = Resources.Load("Respawn");
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
            GetComponent<PlayerMove>().enabled = false;
            hit = true;
        }
        else
        {
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<PlayerMove>().enabled = false;
                dead = true;

                Instantiate(shadow, shadowPos.position, transform.rotation);


            }
        }
    }


    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        anim.ResetTrigger("die");
        anim.Play("idel");
        GetComponent<PlayerMove>().enabled = true;

        GameObject destoctionRef = (GameObject)Instantiate(destoction);
        destoctionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void RespawnMove()
    {
        hit = false;
       
        anim.ResetTrigger("hurt");
        anim.Play("idel");
        GetComponent<PlayerMove>().enabled = true;

    }
}
