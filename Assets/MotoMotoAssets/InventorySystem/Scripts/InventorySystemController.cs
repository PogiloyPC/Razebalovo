using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{
    public class InventorySystemController : MonoBehaviour
    {
        private void Awake()
        {
            ItemData.InitializeItems();
        }
    }
}