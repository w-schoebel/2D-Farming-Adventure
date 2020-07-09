using Assets.Scripts.ItemObjects.Types;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    public class EquipmentManager : MonoBehaviour
    {
        public delegate void OnEquipmentChanged(ArmorItem newItem, ArmorItem oldItem);
        public OnEquipmentChanged onEquipmentChanged;

        public List<ArmorItem> currentEquipment;
        Inventory inventory;

        #region Singleton
        public static EquipmentManager instance;

        void Awake()
        {
            currentEquipment = new List<ArmorItem>();

            if (instance != null)
            {
                Debug.LogWarning("More than one instance of EquipmentManager found!");
                return;
            }
            instance = this;
        }
        #endregion

        private void Start()
        {
            inventory = Inventory.instance;
        }

        public void Equip(ArmorItem newItem, bool isInitial = false)
        {
            ArmorItem oldItem = null;

            if (newItem != null)
            {
                if (!isInitial)
                {
                    ArmorItem currentItem = currentEquipment.Where(item => item != null)?.FirstOrDefault(item => item.armor_Type == newItem.armor_Type);

                    if (currentItem != null)
                    {
                        oldItem = currentItem;
                        currentEquipment.Remove(currentItem);
                        inventory.Add(currentItem);
                    }
                }

                if (onEquipmentChanged != null)
                {
                    onEquipmentChanged.Invoke(newItem, oldItem);
                }

                currentEquipment.Add(newItem);

            }
        }

        public void Unequip(ArmorItem itemToRemove)
        {
            if (itemToRemove != null)
            {
                ArmorItem currentItem = currentEquipment.Where(item => item != null)?.FirstOrDefault(item => itemToRemove.armor_Type == item.armor_Type);

                if (currentItem != null)
                {
                    currentEquipment.Remove(currentItem);
                    inventory.Add(currentItem);

                    if (onEquipmentChanged != null)
                    {
                        onEquipmentChanged.Invoke(null, currentItem);
                    }
                }
            }
        }

        public void UnequipAll()
        {
            new List<ArmorItem>(currentEquipment).ForEach(item => Unequip(item));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                UnequipAll();
            }
        }

        public int GetCurrentAmor()
        {
            int armor = 0;
            for (int i = 0; i < currentEquipment.Count; i++)
            {
                armor = armor + currentEquipment[i].armorValue;
            }

            Debug.Log(armor);

            return armor;
        }

        public int GetCurrentDamage()
        {
            int damage = 0;
            for (int i = 0; i < currentEquipment.Count; i++)
            {
                damage = damage + currentEquipment[i].damageValue;
            }

            return damage;
        }
    }
}
