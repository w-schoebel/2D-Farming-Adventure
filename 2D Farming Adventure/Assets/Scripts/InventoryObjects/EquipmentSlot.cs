/* Author Wiebke Schöbel
 * Created at 15.06.2020
 * Version 3
 * 
 * Controls a specific slot of the equipment
 */
using Assets.Enums;
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls a specific slot of the equipment
    /// </summary>
    public class EquipmentSlot : MonoBehaviour, IPointerClickHandler 
    {
        public UnityEngine.UI.Image icon;
        public ArmorItem item;
        public ArmorType armor_Type;

        /// <summary>
        /// Adds the given item to the slot
        /// </summary>
        /// <param name="newItem"></param>
        public void AddItem(ArmorItem newItem)
        {
            item = newItem;
            if (icon != null)
            {
                icon.sprite = item.icon;
                icon.enabled = true;
            }
        }

        /// <summary>
        /// Removes the item from the slot
        /// </summary>
        public void ClearSlot()
        {
            item = null;
            if (icon != null)
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }

        /// <summary>
        /// Unequips the Item on click
        /// </summary>
        /// <param name="eventData"></param>
        public void OnPointerClick(PointerEventData eventData)
        {
            EquipmentManager.instance.Unequip(item);
        }
    }
}
