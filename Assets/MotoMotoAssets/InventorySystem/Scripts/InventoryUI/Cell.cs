using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
namespace InventorySystem
{
    public enum ContainerType
    {
        all,
        weapon,
        armor
    }
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Image itemIcon;
        public InventoryPlayer inventory;
        public Container container;
        public int containerItemIndex = 0;
        public ContainerType type;
        private void Start()
        {
            itemIcon.gameObject.SetActive(false);
            
        }
        
        public void UpdateCell()
        {
            itemIcon.gameObject.SetActive(true);
            Debug.Log("PATH: " + container.GetItemOrigin(containerItemIndex).getIconPath());
            var s = AssetDatabase.LoadAssetAtPath<Sprite>(container.GetItemOrigin(containerItemIndex).getIconPath() + ".png");
            Debug.Log(s.name);
            itemIcon.sprite = s; 
        }

    }
}

