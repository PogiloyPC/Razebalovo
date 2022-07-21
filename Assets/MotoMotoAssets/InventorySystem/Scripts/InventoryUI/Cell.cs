using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
namespace InventorySystem
{
    public enum ContainerType
    {
        all,
        weapon,
        armor
    }
    public class Cell : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler,IBeginDragHandler,IEndDragHandler, IDragHandler
    {
        [SerializeField] private Image itemIcon;
        public InventoryPlayer inventory;
        public Container container;
        public int containerItemIndex = 0;
        public ContainerType type;
        public TMPro.TextMeshProUGUI ItemCounter;
        public static Cell dragFromCell;
        public static Cell dragToCell;

        private void Start()
        {
            itemIcon.gameObject.SetActive(false);
            
        }
        

        public Sprite getIconImage()
        {
           return AssetDatabase.LoadAssetAtPath<Sprite>(container.GetItemOrigin(containerItemIndex).getIconPath() + ".png");
        }    

        public void UpdateCell()
        {
            if (!container.isEmptyCell(containerItemIndex))
            {
                itemIcon.gameObject.SetActive(true);
                itemIcon.sprite = getIconImage();
                ItemCounter.text = container.GetItemsCount(containerItemIndex).ToString();
            }
            else
            {
                itemIcon.gameObject.SetActive(false);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(dragFromCell!=this) dragToCell = this;

        }
        public void OnPointerExit(PointerEventData eventData)
        {
            dragToCell = null;
        }

        public void OnDrag(PointerEventData eventData)
        {
            PlayerInventoryUI.DragItem.transform.position = eventData.pointerCurrentRaycast.screenPosition;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!container.isEmptyCell(containerItemIndex))
            {
                dragFromCell = this;
                PlayerInventoryUI.DragItem.SetActive(true);
                PlayerInventoryUI.DragItem.GetComponent<Image>().sprite = getIconImage();
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if(dragToCell!=null)
            {
                var indexTo = dragToCell.containerItemIndex;
                dragFromCell.container.PlaceItem(containerItemIndex,indexTo,dragToCell.container);
            }
            dragToCell = null;
            PlayerInventoryUI.DragItem.SetActive(false);
        }

       
    }
}

