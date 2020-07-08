using Assets.Enums;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /*CreateAssetMenu -> tell Unity how to create new Items (fileName is the default file Name, 
      menuName is the path where we are going to navigate in order to create the item)*/
    [CreateAssetMenu(fileName = "New Item", menuName = "Invntory/ArmorItem")]
    [System.Serializable]
    public class ArmorItem : Item
    {
        public int armorValue;
        public int damageValue;
        public ArmorType armor_Type;

        public ArmorItem()
        {
            itemType = ItemType.Armor;
        }

        public override void Use()
        {
            ActingManager.instance.UseArmorItem(this);
        }
    }
}