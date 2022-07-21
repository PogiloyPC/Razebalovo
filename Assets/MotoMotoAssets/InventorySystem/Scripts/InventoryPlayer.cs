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


        private void Awake()
        {
            mainContainer = new Container(55);
            armorContainer = new Container(5);
            weaponContainer = new Container(5);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
