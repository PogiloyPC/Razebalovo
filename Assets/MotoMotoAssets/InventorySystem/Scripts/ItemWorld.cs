using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    /// <summary>
    /// Объект предмета в мире. Взаимодействия пользователя с предметом описанны внутри этого класса. Может существовать 
    /// множество экземпляров данного объекта. Все экзепляры находятся в префабе предмета
    /// </summary>
    public class ItemWorld : MonoBehaviour, IInteractable
    {
        

        public int ID;
        public int count = 1;
        [SerializeField]private Item item;
        void Start()
        {
            item = ItemData.getItemByID(ID);
        }
        public void onAction(GameObject player)
        {
            if(Vector2.Distance(transform.position, player.transform.position)<500)
            {
                if(player.GetComponent<InventoryPlayer>().mainContainer.AddItem(new ItemObject(ID,count)))
                Destroy(this.gameObject);
            }
        }
        public string GetName()
        {
            return item.ItemName;
        }
    }
}
