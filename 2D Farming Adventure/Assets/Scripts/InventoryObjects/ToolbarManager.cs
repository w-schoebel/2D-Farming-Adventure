using Assets.Enums;
using Assets.Scripts.ItemObjects.Types;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
   public class ToolbarManager : MonoBehaviour
    {
        public delegate void OnItemChanged();
        public OnItemChanged itemChangedCallback;

        public int space = 10; // number of slots
        public List<Item> items = new List<Item>();

        #region Singleton

        public static ToolbarManager instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of Toolbar found!");
                return;
            }
            instance = this;
        }

        #endregion

        public bool Add(Item newItem)
        {
            if (newItem == null)
            {
                return false;
            }

            if (!newItem.isDefaultItem)
            {
                
                //checken, über welchem Slot Maus drüber ist -> i
                //items[i].Add(item);

                InvokeItemChangeCallback();
            }

            return true;
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);

            InvokeItemChangeCallback();
        }

        private void InvokeItemChangeCallback()
        {
            if (itemChangedCallback != null)
            {
                itemChangedCallback.Invoke();
            }
        }
    }
}

