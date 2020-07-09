using Assets.Scripts.InventoryObjects.Handler;
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects
{
    public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDropHandler
    {
        public UnityEngine.UI.Image icon;
        public Item item;
        private bool isEntered = false;
        private bool isDragged = false;
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
                item.RemoveFromInventory();
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
                if (Inventory.instance != null && slot_number != -1)
                {
                    Inventory.instance.Add(item, slot_number, itemPosition);
                    item.RemoveFromToolbar();
                }
            }
        }
    }
}
