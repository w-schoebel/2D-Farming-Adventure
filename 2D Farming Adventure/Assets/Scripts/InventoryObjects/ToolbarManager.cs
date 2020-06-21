using Assets.Scripts.ItemObjects.Types;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    public class ToolbarManager : MonoBehaviour
    {
        public delegate void OnItemChanged();
        public OnItemChanged itemChangedCallback;

        public int space = 10; // number of slots
        public Item[] items;

        #region Singleton

        public static ToolbarManager instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            items = new Item[space];

            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of ToolbarManager found!");
                return;
            }
            instance = this;     
        }

        #endregion

        public bool Add(Item newItem, int position, int positionInList)
        {
            if (newItem == null || position >= space)
            {
                return false;
            }

            int oldPosition = Array.IndexOf(items, newItem);

            if(oldPosition > -1)
            {
                items[oldPosition] = items[position];
            }
            else
            {
                Inventory.instance.Add(items[position], positionInList, position);
            }

            items[position] = newItem;

            InvokeItemChangeCallback();

            return true;
        }

        public void RemoveItem(Item item)
        {
           int index = Array.IndexOf(items, item);

            items[index] = null;

            InvokeItemChangeCallback();
        }

        private void InvokeItemChangeCallback()
        {
            if (itemChangedCallback != null)
            {
                itemChangedCallback.Invoke();
            }
        }

        public bool ContainsItem(Item item)
        {
            int index = Array.IndexOf(items, item);
            if (index == -1)
            {
                return false;
            }
            return true;
        }
    }
}

