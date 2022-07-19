using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    public class InventoryPlayer : MonoBehaviour
    {
        public Container mainContainer;
        public Container armorContainer;
        public Container weaponContainer;

        public static InventoryPlayer inventory;

        void Start()
        {
            inventory = this;
            mainContainer = new Container(15);
            armorContainer = new Container(5);
            weaponContainer = new Container(5);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
