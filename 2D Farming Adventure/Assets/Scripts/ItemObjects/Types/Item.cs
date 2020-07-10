/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 8
 * 
 * BaseItem for different itemtypes
 */
using Assets.Enums;
using Assets.Scripts.InventoryObjects;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /// <summary>
    /// BaseItem for different itemtypes 
    /// </summary>
    [System.Serializable]
    public class Item : ScriptableObject
    {
        public string itemName = "New Item";
        public Sprite icon = null;
        public bool isDefaultItem = false;
        public ItemType itemType;

        /// <summary>
        /// Handles item usage
        /// </summary>
        public virtual void Use()
        {

        }

        /// <summary>
        /// Removes the item from inventory
        /// </summary>
        public void RemoveFromInventory()
        {
            if (Inventory.instance != null)
            {
                Inventory.instance.RemoveItem(this);
            }
        }

        /// <summary>
        /// Removes the item from toolbar
        /// </summary>
        public void RemoveFromToolbar()
        {
            if (ToolbarManager.instance != null)
            {
                ToolbarManager.instance.RemoveItem(this);
            }
        }
    }
}
