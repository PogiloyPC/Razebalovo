using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
namespace InventorySystem {
    public class PlayerInventoryUI : MonoBehaviour
    {
        [SerializeField] InventoryPlayer playerInventory;
        [Header("GameObjects Names")]
        [SerializeField] string ItemSlotName = "ItemSlot";
        [Header("Prefabs")]
        [SerializeField] RectTransform ItemsSlotPrefab;
        [Header("ItemPanel Attributes")]
        [SerializeField] RectTransform ItemSlotsContent;
        [SerializeField] int SlotsCountInLine = 5;
        [SerializeField] public static GameObject DragItem;


        public Cell[] itemSlotsCells;


        private void Start()
        {
            DragItem = transform.Find("DragItem").gameObject;
            InstantiateSlots();
            playerInventory.mainContainer.Notify += UpdateCell;
            

        }
        private void Update()
        {
            
        }
        public void UpdateCell(Container sender, ContainerEventArgs args)
        {
            itemSlotsCells[args.Index].UpdateCell();
        }
        private void InstantiateSlots()
        {

            itemSlotsCells = new Cell[playerInventory.mainContainer.Capacity];
            var slotWidth = ItemsSlotPrefab.rect.width;
            var slotHeight = ItemsSlotPrefab.rect.height;
            var padding = (ItemSlotsContent.rect.width / SlotsCountInLine - slotWidth);
            float posY = 0;

            for (int i = 0; i < playerInventory.mainContainer.Capacity; i++)
            {
                var go = Instantiate(ItemsSlotPrefab);
                go.transform.SetParent(ItemSlotsContent.transform);
                go.name = ItemSlotName + i.ToString();
                var rect = go.GetComponent<RectTransform>();
                posY += i%SlotsCountInLine==0 && i>0? padding+slotHeight : 0 ;
                rect.localPosition = new Vector3(padding/2+(i%SlotsCountInLine)*(slotWidth+padding), -padding / 2 -posY, 0);
                
                var cell = go.GetComponent<Cell>();
                cell.containerItemIndex = i;
                cell.container = playerInventory.mainContainer;
                itemSlotsCells[i] = cell;
            }
            ItemSlotsContent.sizeDelta = new Vector2(ItemSlotsContent.sizeDelta.y,posY);
        }

    }
}