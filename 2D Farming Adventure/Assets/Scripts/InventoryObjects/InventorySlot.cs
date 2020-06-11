﻿using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects
{
    public class InventorySlot : MonoBehaviour
        , IPointerClickHandler // 2
        , IDragHandler
        , IPointerEnterHandler
        , IPointerExitHandler
    {
        public UnityEngine.UI.Image icon;
        
        Item item;
        bool isEntered = false;
        bool isDragged = false;
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
            //TODO: item = item aus dem Slot (und nur das eine!)
            if (!isDragged)
            {
                ToolbarManager.instance.Add(item);
            }
            isDragged = true;
            //wenn über Toolbar -> in Toolbarslot einfügen und altes item zurück in InventorySlot
            //wenn über EquipmentDisplay-> in passenden Slot einfügen & altes Item zurück in InventorySlot
        }

        private void OnMouseUp()
        {
            if (isDragged)
            {
                isDragged = false;
            }
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            // UseItem();
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
