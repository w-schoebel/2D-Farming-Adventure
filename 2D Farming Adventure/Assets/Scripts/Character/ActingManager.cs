/* Author Wiebke Schöbel
 * Created at 21.06.2020
 * Version 5
 * 
 * Controls the item usage
 */
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;

namespace Assets.Scripts.Character
{
    /// <summary>
    /// Controls the item usage
    /// </summary>
    public class ActingManager : MonoBehaviour
    {
        private WeaponItem weapon;

        #region Singleton

        public static ActingManager instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of PlayerStats found!");
                return;
            }
            instance = this;
        }

        #endregion
        /// <summary>
        /// Handles the Equip of ArmorItems from Inventory or Toolbar
        /// </summary>
        /// <param name="armor"></param>
        public void UseArmorItem(ArmorItem armor)
        {
            ClearWeapon();

            EquipmentManager.instance.Equip(armor);
            if (Inventory.instance != null)
            {
                if (Inventory.instance.ContainsItem(armor))
                {
                    armor.RemoveFromInventory();
                }
            }
            if (ToolbarManager.instance != null)
            {
                if (ToolbarManager.instance.ContainsItem(armor))
                {
                    armor.RemoveFromToolbar();
                }
            }
        }

        /// <summary>
        /// Handles the consume of a ConsuableItem
        /// </summary>
        /// <param name="consumable"></param>
        public void UseConsumableItem(ConsumableItem consumable)
        {
            ClearWeapon();
            //do sth
            //e.g. heal (if eatable)
        }

        private void ClearWeapon()
        {
            weapon = null;
        }

        /// <summary>
        /// Handles the usage of CraftingItems
        /// </summary>
        /// <param name="craftingMaterial"></param>
        public void UseCraftingMaterialItem(CraftingMaterialItem craftingMaterial)
        {
            ClearWeapon();
            //do sth
            //e.g. show for wich items this craftingMaterial is needed to craft them
        }

        /// <summary>
        /// Handles the usage of WeaponItems
        /// </summary>
        /// <param name="item"></param>
        public void UseWeapon(WeaponItem item)
        {
            int damage = item.GetDamage();
            int endurance = item.GetEndurance();

            if (endurance < damage)
            {
                weapon = item;
            }
            else
            {
                ClearWeapon();
                Work(item);
            }
        }

        /// <summary>
        /// Gets the Damage of the Weapon or 0
        /// </summary>
        /// <returns></returns>
        public int GetCurrentDamage()
        {
            if (weapon == null)
            {
                return 0;
            }
            else
            {
                return weapon.GetDamage();
            }
        }

        /// <summary>
        /// Handles the usage of specific Weapons for Work
        /// </summary>
        /// <param name="item"></param>
        private void Work(WeaponItem item)
        {
            int endurance = item.GetEndurance();
            if (item.itemName.Contains("Axe"))
            {
                if (item.itemName.Contains("Pickaxe"))
                {
                    MineOre();
                }
                else
                {
                    CutTree();
                }
            }
            else if (item.itemName.Contains("Scyther"))
            {
                DoFarmWork();
            }
            Debug.Log("reduce endurance by " + endurance);

            CharacterDecider.instance.GetCurrentCharacterPlayerStats().ConsumeEndurance(endurance);

            //TODO: Animation

        }

        private void DoFarmWork()
        {
            //do sth
        }

        private void CutTree()
        {
            //do sth
        }

        private void MineOre()
        {
            //do sth
        }
    }
}
