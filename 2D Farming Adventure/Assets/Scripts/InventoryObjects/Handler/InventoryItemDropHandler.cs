using Assets.Scripts.ItemObjects.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects.Handler
{
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

        public void OnDrop(PointerEventData eventData)
        {
            if(ItemDragHandler.Instance != null)
            {
                Item item = ItemDragHandler.Instance.GetItem();

                OnItemDropped?.Invoke(this, new OnItemDroppedEventArgs { item = item });
            } 
        }
    }
}
