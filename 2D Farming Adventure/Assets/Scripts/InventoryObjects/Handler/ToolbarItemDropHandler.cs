/* Author Wiebke Schöbel
 * Created at 15.06.2020
 * Version 3
 * 
 * EventHandler for ItemDropHandling specific for Toolbars
 */
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects.Handler
{
    /// <summary>
    /// EventHandler for ItemDropHandling specific for Toolbars
    /// </summary>
    public class ToolbarItemDropHandler : MonoBehaviour, IDropHandler
    {
        public static ToolbarItemDropHandler Instance { get; private set; }

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
