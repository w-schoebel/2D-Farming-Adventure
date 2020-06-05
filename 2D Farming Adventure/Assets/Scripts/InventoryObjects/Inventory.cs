using Assets.Scripts.ItemObjects.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    public class Inventory : MonoBehaviour
    {
        #region Singleton

        public static Inventory instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of Inventory found!");
                return;
            }
            instance = this;
        }

        #endregion

        public delegate void OnItemChanged();
        public OnItemChanged itemChangedCallback;

        public int space = 40; // number of slots
        public List<Item> items = new List<Item>();

        public bool Add(Item item)
        {
            if (item == null)
            {
                return false;
            }

            if (!item.isDefaultItem)
            {
                if (items.Count >= space)
                {
                    Debug.Log("Not enough space in Inventory");
                    return false;
                }

                items.Add(item);

                if (itemChangedCallback != null)
                {
                    itemChangedCallback.Invoke();
                }
            }

            return true;
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);

            if (itemChangedCallback != null)
            {
                itemChangedCallback.Invoke();
            }
        }
    }
}
