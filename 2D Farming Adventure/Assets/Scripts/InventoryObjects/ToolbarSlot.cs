/* Author Wiebke Schöbel
 * Created at 11.06.2020
 * Version 5
 * 
 * Controls a specific slot of the toolbar
 */
using Assets.Scripts.InventoryObjects.Handler;
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls a specific slot of the toolbar
    /// </summary>
    public class ToolbarSlot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IDropHandler
    {
        public Image icon;
        private bool isEntered = false;
        private Item item;
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
                Inventory.instance.RemoveItem(item);
            }
        }

        /// <summary>
        /// Removes the item from the slot
        /// </summary>
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
        /// Removed the item from toolbar if button is pressed
        /// </summary>
        private void RemoveItemWhemButtonPressed()
        {
            if (Input.GetKeyDown(KeyCode.O) && isEntered)
            {
                item.RemoveFromToolbar();
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
        /// Checks if item is in the right position and adds the item to the toolbar
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemPosition"></param>
        private void handleDroppedItem(Item item, int itemPosition)
        {
            //TODO: not working for male
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
