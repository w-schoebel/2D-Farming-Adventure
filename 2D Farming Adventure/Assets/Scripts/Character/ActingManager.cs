using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using System;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class ActingManager : MonoBehaviour
    {
        private int damage;
        private int endurance;
        private WeaponItem weapon;
        private CharacterStats characterStats;

        private void Start()
        {
            // characterStats = GetComponent<CharacterStats>(); // TODO: Anbindung noch richtig bauen mit Maren
        }

        public void UseWeapon(WeaponItem item)
        {
            weapon = item;
            EquipmentManager.instance.GetCurrentAmor();
            if (weapon.enduranceValue < weapon.damageValue)
            {
                attack();
            }
            else
            {
                work();
            }
        }

        private int GetEnduranceValue()
        {
            int enduranceNeeded = weapon.enduranceValue;
            return enduranceNeeded;
        }

        private int GetDamageValue()
        {
            int damageOfWeapon = weapon.damageValue;
            return damageOfWeapon;
        }

        private void attack()
        {
            damage = GetDamageValue();
            Debug.Log("reduce health by " + damage);

            // characterStats.TakeDamage(damage); //vorerst zum Testen sich selbst Schaden zufügen 


            //TODO: Animation
        }

        private void work()
        {
            endurance = GetEnduranceValue();
            if (weapon.itemName.Contains("Axe"))
            {
                if (weapon.itemName.Contains("Pickaxe"))
                {
                    MineOre();
                }
                else
                {
                    CutTree();
                }
            }
            else if (weapon.itemName.Contains("Scyther"))
            {
                DoFarmWork();
            }
            Debug.Log("reduce endurance by " + endurance);
            //  characterStats.ConsumeEndurance(endurance);

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
