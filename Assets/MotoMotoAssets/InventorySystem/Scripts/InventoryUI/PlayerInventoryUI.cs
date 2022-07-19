using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace InventorySystem {
    public class PlayerInventoryUI : MonoBehaviour
    {
        [Header("GameObjects Names")]
        public string ItemSlotName = "ItemSlot";
        [Header("Prefabs")]
        public GameObject ItemsSlotPrefab;
        [Header("ItemPanel Attributes")]
        public GameObject ItemsScrollView;
        public int SlotsCountInLine = 5;



        public GameObject[] itemSlots;

        private void Start()
        {
            for(int i = 0; i < InventoryPlayer.inventory.mainContainer.Capacity; i++)
            {
                var go = Instantiate(ItemsSlotPrefab);
                go.transform.SetParent(ItemsScrollView.transform);
                go.rec = new Vector2();
            }
        }

    }
}