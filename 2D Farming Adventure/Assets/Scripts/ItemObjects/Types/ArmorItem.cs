using Assets.Enums;
using Assets.Scripts.InventoryObjects;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /*CreateAssetMenu -> tell Unity how to create new Items (fileName is the default file Name, 
      menuName is the path where we are going to navigate in order to create the item)*/
    [CreateAssetMenu(fileName = "New Item", menuName = "Invntory/ArmorItem")]
    public class ArmorItem : Item
    {
        public int armorValue;
        public int damageValue;
        public ArmorType armor_Type;

        public ArmorItem()
        {
            itemType = ItemType.Armor;
        }

        public override void Use()
        {
            EquipmentManager.instance.Equip(this);
            if(Inventory.instance != null)
            {
                if (Inventory.instance.ContainsItem(this))
                {
                    RemoveFromInventory();
                }
            }
            if (ToolbarManager.instance != null)
            {
                if (ToolbarManager.instance.ContainsItem(this))
                {
                    RemoveFromToolbar();
                }
            }
        }
    }
}