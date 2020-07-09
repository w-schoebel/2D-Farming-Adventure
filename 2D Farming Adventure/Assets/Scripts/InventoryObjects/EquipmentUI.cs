using Assets.Scripts.Character;
using Assets.Scripts.ItemObjects.Types;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    public class EquipmentUI : MonoBehaviour
    {
        public Transform itemsParent;
        public GameObject equipment_UI;
        public GameObject equipmentBackground;

        EquipmentManager equipmentManager;
        EquipmentSlot[] equipmentSlots;

        // Start is called before the first frame update
        void Start()
        {
            equipmentManager = EquipmentManager.instance;
            equipmentManager.onEquipmentChanged += UpdateUI; //Event that triggers UpdateUI

            equipmentSlots = itemsParent.GetComponentsInChildren<EquipmentSlot>();
            SetPicture();
            UpdateUiIinitial();
        }

        private void SetPicture()
        {
            if (CharacterDecider.instance != null)
            {
                Image sourceImage = equipmentBackground.GetComponent<Image>();
                sourceImage.sprite = CharacterDecider.instance.GetCurrentCharacterPlayerStats().GetSpecificSprite();
            }
        }

        void UpdateUiIinitial()
        {
            foreach (ArmorItem armorItem in equipmentManager.currentEquipment)
            {
                UpdateUI(armorItem, null);
            }
        }

        void UpdateUI(ArmorItem newItem, ArmorItem oldItem)
        {
            if (newItem != null)
            {
                equipmentSlots.FirstOrDefault(slot => slot.armor_Type == newItem.armor_Type)?.AddItem(newItem);
            }
            else if (oldItem != null)
            {
                equipmentSlots.FirstOrDefault(slot => slot.armor_Type == oldItem.armor_Type)?.ClearSlot();
            }
        }
    }
}
