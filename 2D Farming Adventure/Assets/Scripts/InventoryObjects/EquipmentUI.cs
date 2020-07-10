/* Author Wiebke Schöbel
 * Created at 15.06.2020
 * Version 5
 * 
 * Controls the ui for the equipment
 */
using Assets.Scripts.Character;
using Assets.Scripts.ItemObjects.Types;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls the ui for the equipment
    /// </summary>
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

        /// <summary>
        /// Sets the Sprite from the active character in the background of the equipment
        /// </summary>
        private void SetPicture()
        {
            if (CharacterDecider.instance != null)
            {
                Image sourceImage = equipmentBackground.GetComponent<Image>();
                sourceImage.sprite = CharacterDecider.instance.GetCurrentCharacterPlayerStats().GetSpecificSprite();
            }
        }

        /// <summary>
        /// Updates the UI for loading the character initial
        /// </summary>
        void UpdateUiIinitial()
        {
            foreach (ArmorItem armorItem in equipmentManager.currentEquipment)
            {
                UpdateUI(armorItem, null);
            }
        }

        /// <summary>
        /// Updates the ui for new item
        /// </summary>
        /// <param name="newItem"></param>
        /// <param name="oldItem"></param>
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
