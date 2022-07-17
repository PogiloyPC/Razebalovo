using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGive : MonoBehaviour
{

    public int speed;


    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

    }
}
