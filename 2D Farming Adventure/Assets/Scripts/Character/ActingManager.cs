using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;

namespace Assets.Scripts.Character
{
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

        public void UseCraftingMaterialItem(CraftingMaterialItem craftingMaterial)
        {
            ClearWeapon();
            //do sth
            //e.g. show for wich items this craftingMaterial is needed to craft them
        }

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
                work(item);
            }
        }

        public int GetCurrentDamage()
        {
            if(weapon == null)
            {
                return 0;
            }
            else
            {
                return weapon.GetDamage();
            }
        }

        private void work(WeaponItem item)
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
