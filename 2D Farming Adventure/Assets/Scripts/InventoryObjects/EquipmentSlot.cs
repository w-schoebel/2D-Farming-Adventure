using Assets.Enums;
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.InventoryObjects
{
    public class EquipmentSlot : MonoBehaviour
        , IPointerClickHandler // 2
        , IPointerEnterHandler
        , IPointerExitHandler
    {
        public UnityEngine.UI.Image icon;
        public ArmorItem item;
        public ArmorType armor_Type;
        private bool isEntered = false;
        
        public void AddItem(ArmorItem newItem)
        {
            item = newItem;
            if (icon != null)
            {
                icon.sprite = item.icon;
                icon.enabled = true;
            }
        }

        public void ClearSlot()
        {
            item = null;
            if (icon != null)
            {
                icon.sprite = null;
                icon.enabled = false;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            EquipmentManager.instance.Unequip(item);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isEntered = true;
            //TODO: show stats information
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isEntered = false;
            //TODO: remove stats information
        }
    }
}
