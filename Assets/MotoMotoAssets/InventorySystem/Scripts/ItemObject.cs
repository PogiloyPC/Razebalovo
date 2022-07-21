using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    [System.Serializable]
    public struct ItemObject
    {
        public int item_ID;
        public int count;

        public Item refItem
        {
            get { return ItemData.getItemByID(item_ID); }
        }

        public ItemObject(int ID, int count)
        {
            this.item_ID = ID;
            this.count = count;
        }
    }
}