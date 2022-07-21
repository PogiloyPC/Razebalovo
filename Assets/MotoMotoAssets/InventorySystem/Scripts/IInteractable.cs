using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    public interface IInteractable
    {

        public void onAction(GameObject player);
        public string GetName();
    }
}