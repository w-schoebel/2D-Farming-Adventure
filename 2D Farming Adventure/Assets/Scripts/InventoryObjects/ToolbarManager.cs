/* Author Wiebke Schöbel
 * Created at 10.06.2020
 * Version 7
 * 
 * Controls the toolbar
 */
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls the toolbar
    /// </summary>
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

        /// <summary>
        /// Adds the item to the inventory (specific position handling)
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="position"></param>
        /// <param name="positionInList"></param>
        /// <returns></returns>
        public bool Add(Item newItem, int position, int positionInList)
        {
            if (newItem == null || position >= space)
            {
                return false;
            }

            int oldPosition = Array.IndexOf(items, newItem);

            if (oldPosition > -1)
            {
                items[oldPosition] = items[position];
            }
            else if (positionInList > -1)
            {
                Inventory.instance.Add(items[position], positionInList, position);
            }

            items[position] = newItem;

            InvokeItemChangeCallback();

            return true;
        }

        /// <summary>
        /// Remove item from inventory
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItem(Item item)
        {
            int index = Array.IndexOf(items, item);

            if (index != -1)
            {
                items[index] = null;
                InvokeItemChangeCallback();
            }
        }

        /// <summary>
        /// Called to update the slots with new item
        /// </summary>
        private void InvokeItemChangeCallback()
        {
            if (itemChangedCallback != null)
            {
                itemChangedCallback.Invoke();
            }
        }

        /// <summary>
        /// Check if given item exists in toolbar
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

