using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace InventorySystem
{
    
    public static class ItemData
    {
        public static List<Item> itemsData = new List<Item>();
        
        public static void InitializeItems()
        {
            registerItem(new Item(-1, "EMPTYFIELDNULLITEM", "NULLITEMEMPTYFIELD"));
            registerItem(new Item(0,"ITEM0","ITEM0DESCRIPTION"));
        }
        public static void registerItem(Item item)
        {
            itemsData.Add(item);
        }
        public static Item getItemByID(int id)
        {
            var i = itemsData.First(t => t.ItemID == id);
            return i;
        }
    }
}