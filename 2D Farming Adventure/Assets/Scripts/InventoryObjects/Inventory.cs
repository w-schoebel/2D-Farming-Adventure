/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 9
 * 
 * Controls the inventory
 */
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls the inventory
    /// </summary>
    public class Inventory : MonoBehaviour
    {

        public delegate void OnItemChanged();
        public OnItemChanged itemChangedCallback;

        public int space = 40; // number of slots
        public Item[] items;

        #region Singleton

        public static Inventory instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            items = new Item[space];

            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of Inventory found!");
                return;
            }
            instance = this;
        }

        #endregion

        /// <summary>
        /// Adds the item to the inventory
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Add(Item item)
        {
            if (item == null)
            {
                return false;
            }

            if (!Array.Exists(items, element => element == null) && items.Length >= space)
            {
                Debug.Log("Not enough space in Inventory");
                return false;
            }

            int index = Array.FindIndex(items, i => i == null);

            items[index] = item;

            InvokeItemChangeCallback();

            return true;
        }

        /// <summary>
        /// Adds the item to the inventory (specific position handling)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="position"></param>
        /// <param name="positionInToolbar"></param>
        /// <returns></returns>
        public bool Add(Item item, int position, int positionInToolbar)
        {
            if (item == null || position >= space)
            {
                return false;
            }

            int oldPosition = Array.IndexOf(items, item);

            if (oldPosition > -1)
            {
                items[oldPosition] = items[position];
            }
            else if (positionInToolbar > -1)
            {
                ToolbarManager.instance.Add(item, positionInToolbar, position);
            }

            items[position] = item;

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

            if (index > -1 && index < space)
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
        /// Check if given item exists in inventory
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