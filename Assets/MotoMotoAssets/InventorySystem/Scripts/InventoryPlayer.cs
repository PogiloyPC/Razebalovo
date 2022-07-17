using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    public class InventoryPlayer : MonoBehaviour
    {
        public Container container;
        void Start()
        {
            container = new Container(15);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
