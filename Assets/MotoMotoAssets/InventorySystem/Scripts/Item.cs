using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{

    public enum ItemType
    {
        empty
    }

    [System.Serializable]
    public class Item
    {

        

        public const string iconPath = "/";


        private int item_ID;
        private string item_Name;
        private string item_Desription;
        private ItemType item_Type;
        public int ItemID
        {
            get
            {
                return item_ID;
            }
            private set { item_ID = value; }
        }

        public string ItemName
        {
            get
            {
                return item_Name;
            }
        }

        private string ItemDescription
        {
            get { return item_Desription; }
        }

        public Item(int item_id, string item_name, string item_description = "",ItemType item_type = ItemType.empty)
        {
            this.item_ID = item_id;
            this.item_Name = item_name;
            this.item_Desription = item_description;
            this.item_Type = item_type;
        }

        public string getIconPath()
        {
            return iconPath + "/" + item_Name + "_" + item_ID.ToString();
        }

    }
}