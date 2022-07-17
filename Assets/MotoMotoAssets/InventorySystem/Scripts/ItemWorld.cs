using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace InventorySystem
{
    /// <summary>
    /// ������ �������� � ����. �������������� ������������ � ��������� �������� ������ ����� ������. ����� ������������ 
    /// ��������� ����������� ������� �������. ��� ��������� ��������� � ������� ��������
    /// </summary>
    public class ItemWorld : MonoBehaviour, IInteractable
    {
        public static int interactDistance = 50;

        public int ID;
        public int count = 1;
        private Item item;
        void Start()
        {
            item = ItemData.getItemByID(ID);
        }
        public void onAction(GameObject player)
        {
            if(Vector2.Distance(this.transform.position, player.transform.position)<50)
            {
                if(player.GetComponent<InventoryPlayer>().mainContainer.AddItem(new ItemObject(ID,count)))
                Destroy(this.gameObject);
            }
        }
    }
}
