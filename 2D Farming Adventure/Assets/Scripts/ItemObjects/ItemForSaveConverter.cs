/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 3
 * 
 * Handles the convertation between item and itemForSave
 */
using Assets.Scripts.ItemObjects.Types;

namespace Assets.Scripts.ItemObjects
{
    /// <summary>
    /// Handles the convertation between item and itemForSave
    /// </summary>
    public class ItemForSaveConverter
    {
        /// <summary>
        /// Returns the specific item that was parsed before to the itemForSave
        /// </summary>
        /// <param name="itemForSave"></param>
        /// <returns></returns>
        public Item ConvertFromItemForSave(ItemForSave itemForSave)
        {
            if (itemForSave == null)
            {
                return null;
            }

            switch (itemForSave.itemType)
            {
                case Enums.ItemType.Armor:
                    return CreateArmorItem(itemForSave);
                case Enums.ItemType.Weapon:
                    return CreateWeaponItem(itemForSave);
                case Enums.ItemType.Consumable:
                    return CreateConsumableItem(itemForSave);
                case Enums.ItemType.CraftMaterial:
                    return CreateCraftingMaterialItem(itemForSave);
                default:
                    return null;
            }

        }

        /// <summary>
        /// Create an armor item from a given itemForSave
        /// </summary>
        /// <param name="itemForSave"></param>
        /// <returns></returns>
        private ArmorItem CreateArmorItem(ItemForSave itemForSave)
        {
            ArmorItem item = new ArmorItem();
            item.armorValue = itemForSave.armorValue;
            item.damageValue = itemForSave.damageValue;
            item.armor_Type = itemForSave.armor_Type;

            SetCommonProperties(itemForSave, item);

            return item;
        }

        /// <summary>
        /// Create an weapon item from a given itemForSave
        /// </summary>
        /// <param name="itemForSave"></param>
        /// <returns></returns>
        private WeaponItem CreateWeaponItem(ItemForSave itemForSave)
        {
            WeaponItem item = new WeaponItem();
            item.SetDamage(itemForSave.damageValue);
            item.SetEndurance(itemForSave.enduranceValue);

            SetCommonProperties(itemForSave, item);

            return item;
        }

        /// <summary>
        /// Create an consumable item from a given itemForSave
        /// </summary>
        /// <param name="itemForSave"></param>
        /// <returns></returns>
        private ConsumableItem CreateConsumableItem(ItemForSave itemForSave)
        {
            ConsumableItem item = new ConsumableItem();

            SetCommonProperties(itemForSave, item);

            return item;
        }

        /// <summary>
        /// Create an crafting material item from a given itemForSave
        /// </summary>
        /// <param name="itemForSave"></param>
        /// <returns></returns>
        private CraftingMaterialItem CreateCraftingMaterialItem(ItemForSave itemForSave)
        {
            CraftingMaterialItem item = new CraftingMaterialItem();

            SetCommonProperties(itemForSave, item);

            return item;
        }

        /// <summary>
        /// Returns the itemForSave for a given specific item tpye
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public ItemForSave ConvertFromItem(Item item)
        {
            if (item == null)
            {
                return null;
            }

            switch (item.itemType)
            {
                case Enums.ItemType.Armor:
                    return ConvertFromItem((ArmorItem)item);
                case Enums.ItemType.Weapon:
                    return ConvertFromItem((WeaponItem)item);
                case Enums.ItemType.Consumable:
                    return ConvertFromItem((ConsumableItem)item);
                case Enums.ItemType.CraftMaterial:
                    return ConvertFromItem((CraftingMaterialItem)item);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Creates an itemForSave for a given WeaponItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ItemForSave ConvertFromItem(WeaponItem item)
        {
            ItemForSave itemForSave = new ItemForSave();
            itemForSave.damageValue = item.GetDamage();
            itemForSave.enduranceValue = item.GetEndurance();

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        /// <summary>
        /// Creates an itemForSave for a given ArmrorItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ItemForSave ConvertFromItem(ArmorItem item)
        {
            ItemForSave itemForSave = new ItemForSave();
            itemForSave.armorValue = item.armorValue;
            itemForSave.damageValue = item.damageValue;
            itemForSave.armor_Type = item.armor_Type;

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        /// <summary>
        /// Creates an itemForSave for a given ConsumableItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ItemForSave ConvertFromItem(ConsumableItem item)
        {
            ItemForSave itemForSave = new ItemForSave();

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        /// <summary>
        /// Creates an itemForSave for a given CraftingMaterialItem
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private ItemForSave ConvertFromItem(CraftingMaterialItem item)
        {
            ItemForSave itemForSave = new ItemForSave();

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        /// <summary>
        /// Set common properties for ItemForSave from given Item
        /// </summary>
        /// <param name="sourceItem"></param>
        /// <param name="targetItem"></param>
        private void SetCommonProperties(Item sourceItem, ItemForSave targetItem)
        {
            targetItem.itemName = sourceItem.itemName;
            targetItem.SetSprite(sourceItem.icon);
            targetItem.isDefaultItem = sourceItem.isDefaultItem;
            targetItem.itemType = sourceItem.itemType;
        }

        /// <summary>
        /// Set common properties for Item from given ItemForSave
        /// </summary>
        /// <param name="sourceItem"></param>
        /// <param name="targetItem"></param>
        private void SetCommonProperties(ItemForSave sourceItem, Item targetItem)
        {
            targetItem.itemName = sourceItem.itemName;
            targetItem.icon = sourceItem.GetSprite();
            targetItem.isDefaultItem = sourceItem.isDefaultItem;
            targetItem.itemType = sourceItem.itemType;
        }
    }
}

