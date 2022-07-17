using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace InventorySystem
{
    [System.Serializable]
    public class Container
    {
        [SerializeField]
        private ItemObject[] containItems;

        public Container(int itemCapacity)
        {
            this.containItems = new ItemObject[itemCapacity];
        }

        public bool AddItem(ItemObject itemObject)
        {
            for(int i = 0; i < containItems.Length; i++)
            {
                if(containItems[i].count<1)
                {
                    if(containItems[i].item_ID == itemObject.item_ID)
                    {
                        containItems[i].count+=itemObject.count;
                    }
                    else
                    {
                        containItems[i] = itemObject;
                    }
                    return true;
                }
            }
            return false;
        }
        public bool isEmptyCell(int index)
        {
            return containItems[index].count < 1;
        }
        public bool SetItem(int index,ItemObject item)
        {
            if(isEmptyCell(index))
            {
                containItems[index] = item;
                return true;
            }
            return false;
        }

    }
}