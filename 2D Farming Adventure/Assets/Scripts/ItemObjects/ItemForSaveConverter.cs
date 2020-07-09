using Assets.Scripts.ItemObjects.Types;

namespace Assets.Scripts.ItemObjects
{
    public class ItemForSaveConverter
    {

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

        private ArmorItem CreateArmorItem(ItemForSave itemForSave)
        {
            ArmorItem item = new ArmorItem();
            item.armorValue = itemForSave.armorValue;
            item.damageValue = itemForSave.damageValue;
            item.armor_Type = itemForSave.armor_Type;

            SetCommonProperties(itemForSave, item);

            return item;
        }

        private WeaponItem CreateWeaponItem(ItemForSave itemForSave)
        {
            WeaponItem item = new WeaponItem();
            item.SetDamage(itemForSave.damageValue);
            item.SetEndurance(itemForSave.enduranceValue);

            SetCommonProperties(itemForSave, item);

            return item;
        }

        private ConsumableItem CreateConsumableItem(ItemForSave itemForSave)
        {
            ConsumableItem item = new ConsumableItem();

            SetCommonProperties(itemForSave, item);

            return item;
        }

        private CraftingMaterialItem CreateCraftingMaterialItem(ItemForSave itemForSave)
        {
            CraftingMaterialItem item = new CraftingMaterialItem();

            SetCommonProperties(itemForSave, item);

            return item;
        }

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

        private ItemForSave ConvertFromItem(WeaponItem item)
        {
            ItemForSave itemForSave = new ItemForSave();
            itemForSave.damageValue = item.GetDamage();
            itemForSave.enduranceValue = item.GetEndurance();

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        private ItemForSave ConvertFromItem(ArmorItem item)
        {
            ItemForSave itemForSave = new ItemForSave();
            itemForSave.armorValue = item.armorValue;
            itemForSave.damageValue = item.damageValue;
            itemForSave.armor_Type = item.armor_Type;

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        private ItemForSave ConvertFromItem(ConsumableItem item)
        {
            ItemForSave itemForSave = new ItemForSave();

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        private ItemForSave ConvertFromItem(CraftingMaterialItem item)
        {
            ItemForSave itemForSave = new ItemForSave();

            SetCommonProperties(item, itemForSave);

            return itemForSave;
        }

        private void SetCommonProperties(Item sourceItem, ItemForSave targetItem)
        {
            targetItem.itemName = sourceItem.itemName;
            targetItem.SetSprite(sourceItem.icon);
            targetItem.isDefaultItem = sourceItem.isDefaultItem;
            targetItem.itemType = sourceItem.itemType;
        }

        private void SetCommonProperties(ItemForSave sourceItem, Item targetItem)
        {
            targetItem.itemName = sourceItem.itemName;
            targetItem.icon = sourceItem.GetSprite();
            targetItem.isDefaultItem = sourceItem.isDefaultItem;
            targetItem.itemType = sourceItem.itemType;
        }
    }
}

