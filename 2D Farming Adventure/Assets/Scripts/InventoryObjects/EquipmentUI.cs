using Assets.Scripts.ItemObjects.Types;
using System.Linq;
using UnityEngine;

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
