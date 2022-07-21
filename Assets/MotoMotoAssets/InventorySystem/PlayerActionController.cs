using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem;
public class PlayerActionController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null)
            {
                var interact = hit.collider.gameObject.GetComponent<IInteractable>();
                Debug.Log(interact.GetName());
                interact.onAction(gameObject);
               
            }
        }
    }
}
