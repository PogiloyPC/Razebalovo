using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    [System.Serializable]
    public class ItemObject
    {
        const int EMPTYITEM = -1;
        public int item_ID = EMPTYITEM;
        public int count = EMPTYITEM;

        public Item refItem;

        public ItemObject()
        {
            this.item_ID = EMPTYITEM;
            this.count = EMPTYITEM;
        }
        public ItemObject(int ID, int count)
        {
            this.item_ID = ID;
            this.count = count;
            refItem = ItemData.getItemByID(ID);
        }
    }
}