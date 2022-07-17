using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalingCheck : MonoBehaviour
{

    


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag.Equals("Ground"))
        {
            Debug.Log(PlayerMove.body.velocity.y);
           
        }
        if (collision.gameObject.tag.Equals("Ground") && PlayerMove.body.velocity.y < -1)
        {
            if (collision.tag == "Player")
            {
                collision.GetComponent<Health>().TakeDamage(70);

            }
            Debug.Log("Damage");
        }

    }
}
