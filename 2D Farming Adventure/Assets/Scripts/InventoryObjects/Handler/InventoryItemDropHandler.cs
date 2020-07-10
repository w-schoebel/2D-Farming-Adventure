/* Author Wiebke Schöbel
 * Created at 15.06.2020
 * Version 4
 * 
 * EventHandler for ItemDropHandling specific for Inventory
 */
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects.Handler
{
    /// <summary>
    /// EventHandler for ItemDropHandling specific for Inventory
    /// </summary>
    public class InventoryItemDropHandler : MonoBehaviour, IDropHandler
    {
        public static InventoryItemDropHandler Instance { get; private set; }

        public event EventHandler<OnItemDroppedEventArgs> OnItemDropped;

        private void Awake()
        {
            Instance = this;
        }

        public class OnItemDroppedEventArgs : EventArgs
        {
            public Item item;
        }

        /// <summary>
        /// Sets the dropped Item and calls the itemDroppedEvent
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrop(PointerEventData eventData)
        {
            if (ItemDragHandler.Instance != null)
            {
                Item item = ItemDragHandler.Instance.GetItem();

                OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item });
            }
        }
    }
}
