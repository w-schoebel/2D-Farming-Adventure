using Assets.Scripts.InventoryObjects.Handler;
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    public class ToolbarSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDropHandler
    {
        public Image icon;
        private bool isEntered = false;
        private Item item;
        private int slot_number = -1;

        public void AddItem(Item newItem)
        {
            if (newItem != null)
            {
                item = newItem;
                if (icon != null)
                {
                    icon.sprite = item.icon;
                    icon.enabled = true;
                }
                Inventory.instance.RemoveItem(item);
            }
        }

        public void ClearSlot()
        {
      //      bool wasMoved = Inventory.instance.Add(item); //add item to Inventory again before removing it from Toolbar
      //      if (wasMoved)
      //      {
                item = null;
                if (icon != null)
                {
                    icon.sprite = null;
                    icon.enabled = false;
                }
      //      }
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
                item.RemoveFromToolbar();
            }
        }

        public void UseItem()
        {
            if (item != null)
            {
                item.Use();
            }
        }

        public void SetSlotNumber(int slotNumber)
        {
            this.slot_number = slotNumber;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (ItemDragHandler.Instance != null)
            {
                ItemDragHandler itemDragHandler = ItemDragHandler.Instance;
                itemDragHandler.SetItem(item);
                itemDragHandler.SetItemPosition(slot_number);
            }
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (ItemDragHandler.Instance != null)
            {
                Item item = ItemDragHandler.Instance.GetItem();
                int itemPosition = ItemDragHandler.Instance.GetItemPosition();


                handleDroppedItem(item, itemPosition);
            }
        }

        private void handleDroppedItem(Item item, int itemPosition)
        {
            RectTransform invPanel = transform as RectTransform;
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (RectTransformUtility.RectangleContainsScreenPoint(invPanel, worldPosition))
            {
                if (ToolbarManager.instance != null && slot_number != -1)
                {
                    ToolbarManager.instance.Add(item, slot_number, itemPosition);
                }
            }
        }
    }
}
