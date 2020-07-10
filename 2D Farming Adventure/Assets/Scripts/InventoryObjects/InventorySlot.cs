/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 8
 * 
 * Controls a specific slot of the inventory
 */
using Assets.Scripts.InventoryObjects.Handler;
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls a specific slot of the inventory
    /// </summary>
    public class InventorySlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDropHandler
    {
        public UnityEngine.UI.Image icon;
        public Item item;
        private bool isEntered = false;
        private int slot_number = -1;

        /// <summary>
        /// Adds the given item to the slot
        /// </summary>
        /// <param name="newItem"></param>
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
        
        /// <summary>
        /// Removes the item from the slot
        /// </summary>
        public void ClearSlot()
        {
            item = null;
            if (icon != null)
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }

        /// <summary>
        /// Calls the item to be used after click
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            UseItem();
        }

        /// <summary>
        /// Set isEntered to true if pointer entered
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            isEntered = true;
        }

        /// <summary>
        /// Set isEntered to false if pointer left
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerExit(PointerEventData eventData)
        {
            isEntered = false;
        }

        /// <summary>
        /// Calls to remove an item if button is pressed
        /// </summary>
        private void Update()
        {
            RemoveItemWhemButtonPressed();
        }

        /// <summary>
        /// Removed the item from inventory if button is pressed
        /// </summary>
        private void RemoveItemWhemButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.O) && isEntered)
            {
                item.RemoveFromInventory();
            }
        }

        /// <summary>
        /// Uses the Item
        /// </summary>
        public void UseItem()
        {
            if (item != null)
            {
                item.Use();
            }
        }

        /// <summary>
        /// Set the number of the slot for a given slotNumber
        /// </summary>
        /// <param name="slotNumber"></param>
        public void SetSlotNumber(int slotNumber)
        {
            this.slot_number = slotNumber;
        }

        /// <summary>
        /// Handles ItemDragging from inventory if mouse is clicked down
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerDown(PointerEventData eventData)
        {
            if (ItemDragHandler.Instance != null)
            {
                ItemDragHandler itemDragHandler = ItemDragHandler.Instance;
                itemDragHandler.SetItem(item);
                itemDragHandler.SetItemPosition(slot_number);
            }
        }

        /// <summary>
        /// Handles item on dropped position
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (ItemDragHandler.Instance != null)
            {
                Item item = ItemDragHandler.Instance.GetItem();
                int itemPosition = ItemDragHandler.Instance.GetItemPosition();
                handleDroppedItem(item, itemPosition);
            }

        }

        /// <summary>
        /// Checks if item is in the right position, adds the item to the inventory, removes item from toolbar
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemPosition"></param>
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
