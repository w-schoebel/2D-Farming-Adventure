using Assets.Enums;
using Assets.Scripts.InventoryObjects;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    public class Item : ScriptableObject
    {
        public string item_name = "New Item";
        public Sprite icon = null;
        public bool isDefaultItem = false;
        public ItemType item_Type;

        public virtual void Use()
        {

        }

        public void RemoveFromInventory()
        {
            if(Inventory.instance != null)
            {
                Inventory.instance.RemoveItem(this);
            }
        }

        public void RemoveFromToolbar()
        {
            if (ToolbarManager.instance != null)
            {
                ToolbarManager.instance.RemoveItem(this);
            }
        }
    }
}
