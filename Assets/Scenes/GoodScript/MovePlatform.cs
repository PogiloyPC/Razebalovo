using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{


    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    

    private bool movingLeft;
    private float leftEdge;
    private float rigthEdge;


    private void Awake()
    {
        leftEdge = transform.position.y - movementDistance;
        rigthEdge = transform.position.y + movementDistance;
    }


    private void Update()
    {
        if (movingLeft)
        {
            if (transform.position.y > leftEdge)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y - speed * Time.deltaTime, transform.position.z);

            }
            else
                movingLeft = false;

        }
        else
        {
            if (transform.position.y < rigthEdge)
            {
                transform.position = new Vector3(transform.position.x , transform.position.y + speed * Time.deltaTime, transform.position.z);
            }
            else
                movingLeft = true;

        }
    }
}
