using Assets.Scripts.Character;
using Assets.Scripts.ItemObjects.Types;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    public class EquipmentUI : MonoBehaviour
    {
        public Transform itemsParent;
        public GameObject equipment_UI;

        EquipmentManager equipmentManager;
        EquipmentSlot[] equipmentSlots; 

        // Start is called before the first frame update
        void Start()
        {
            equipmentManager = EquipmentManager.instance;
            equipmentManager.onEquipmentChanged += UpdateUI; //Event that triggers UpdateUI

            equipmentSlots = itemsParent.GetComponentsInChildren<EquipmentSlot>();
            SetPicture();
        }

        private void SetPicture()
        {/*
            Image image = itemsParent.GetComponentInChildren<Image>();
            image.sprite = ;//Sprite vom Spieler
            */
        }

        void UpdateUI(ArmorItem newItem, ArmorItem oldItem)
        {
            if (newItem != null)
            {
                equipmentSlots.FirstOrDefault(slot => slot.armor_Type == newItem.armor_Type)?.AddItem(newItem);
            } else
            {
                equipmentSlots.FirstOrDefault(slot => slot.armor_Type == oldItem.armor_Type)?.ClearSlot();
            }
        }
    }
}
