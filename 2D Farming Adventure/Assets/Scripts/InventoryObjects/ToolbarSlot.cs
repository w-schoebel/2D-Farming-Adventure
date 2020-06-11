using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    public class ToolbarSlot : MonoBehaviour
         , IPointerClickHandler // 2
          , IDragHandler
          , IPointerEnterHandler
          , IPointerExitHandler
    {
        public Image icon;
        public bool isEntered = false;

        Item item;
        public void AddItem(Item newItem)
        {
            item = newItem;
            if (icon != null)
            {
                icon.sprite = item.icon;
                icon.enabled = true;
            }
            Inventory.instance.RemoveItem(item);
        }

        public void ClearSlot()
        {
            bool wasMoved = Inventory.instance.Add(item); //add item to Inventory again before removing it from Toolbar
            if (wasMoved)
            {
                item = null;
                if (icon != null)
                {
                    icon.sprite = null;
                    icon.enabled = false;
                }
            }
        }


        public void OnDrag(PointerEventData eventData)
        {
            throw new NotImplementedException();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UseItem();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isEntered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isEntered = false;
        }

        private void Start()
        {

            
        }
        private void Update()
        {

            RemoveItemWhemButtonPressed();
        }

        private void RemoveItemWhemButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.O) && isEntered)
            {
                ToolbarManager.instance.RemoveItem(item);
            }
        }

        public void UseItem()
        {
            if (item != null)
            {
                item.Use();
            }
        }
       
    }
}
