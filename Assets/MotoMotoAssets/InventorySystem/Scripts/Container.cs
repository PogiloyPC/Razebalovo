using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
namespace InventorySystem
{
    [System.Serializable]
    public class Container
    {
        [SerializeField]
        private ItemObject[] containItems;

        #region Events
        public delegate void ContainerHandler(Container sender, ContainerEventArgs e);
        /// <summary>
        /// Вызывается при любой операции с элементами массива
        /// </summary>
        public event ContainerHandler? Notify;
        #endregion
        #region Getters
        public int Capacity
        {
            get { return containItems.Length; }
        }
        #endregion
        #region Constructors
        public Container(int itemCapacity)
        {
            this.containItems = new ItemObject[itemCapacity];
        }
        #endregion
        #region ArrayInteraction
        public bool AddItem(ItemObject itemObject)
        {
            Debug.Log(containItems.Length);
            for (int i = 0; i < containItems.Length; i++)
            {
                Debug.Log("Contain ID: " + containItems[i].item_ID + " Contain Count:" + containItems[i].count + ";\n" +
                       "ItemObject id: " + itemObject.item_ID + " ItemObject count: " + itemObject.count);
                if (containItems[i].item_ID == itemObject.item_ID)
                {
                    containItems[i].count += itemObject.count;
                    Notify?.Invoke(this, new ContainerEventArgs("Container", i));
                    return true;
                }
                else if (containItems[i].count<1)
                {
                   containItems[i] = itemObject;
                   Notify?.Invoke(this, new ContainerEventArgs("Container",i));
                   return true;
                }

            }
            return false;
        }
        public bool SetItem(int index, ItemObject item)
        {
            if (isEmptyCell(index))
            {
                containItems[index] = item;
                Notify?.Invoke(this, new ContainerEventArgs("Container", index));
                return true;
            }
            else if (isEqualItem(index, item))
            {
                containItems[index].count += item.count;
                Notify?.Invoke(this, new ContainerEventArgs("Container", index));
                return true;
            }
            return false;
        }
        public ItemObject RemoveItem(int index)
        {
            var removed = containItems[index];
            containItems[index] = new ItemObject();
            Notify?.Invoke(this, new ContainerEventArgs("Container", index));
            return removed;
        }
        #endregion
        #region UtilitesArrayInteraction
        public ItemObject GetItemObjectInContainer(int index)
        {
            return containItems[index];
        }
        public bool PlaceItem(int from, int to, Container intoContainer)
        {
            var replacedItem = containItems[from];
            if (intoContainer.SetItem(to, replacedItem))
            {
                RemoveItem(from);
                return true;
            }
            return false;
        }  
        public Item GetItemOrigin(int index)
        {
            return containItems[index].refItem;
        }
      
        public bool isEmptyCell(int index)
        {
            return containItems[index].count < 1;
        }
        public bool isEqualItem(int index, ItemObject item)
        {
            return containItems[index].item_ID == item.item_ID;
        }
        #endregion
    }
}