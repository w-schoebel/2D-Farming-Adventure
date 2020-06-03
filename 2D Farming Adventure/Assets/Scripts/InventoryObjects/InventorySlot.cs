using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    public class InventorySlot : MonoBehaviour
        , IPointerClickHandler // 2
         , IDragHandler
         , IPointerEnterHandler
         , IPointerExitHandler
    {
        public Image icon;

        Item item;
        bool isEntered = false;

        public void AddItem(Item newItem)
        {
            item = newItem;
            if (icon != null)
            {
                icon.sprite = item.icon;
                icon.enabled = true;
            }
        }

        public void ClearSlot()
        {
            item = null;
            if (icon != null)
            {
                icon.sprite = null;
                icon.enabled = false;
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

        private void Update()
        {
            RemoveItemWhemButtonPressed();
        }

        private void RemoveItemWhemButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.O) && isEntered)
            {
                Inventory.instance.RemoveItem(item);
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
