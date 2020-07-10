/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 8
 * 
 * Specific armor itemtype
 */
using Assets.Enums;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /// <summary>
    /// Specific armor itemtype 
    /// </summary>
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

        /// <summary>
        /// Handles item usage
        /// </summary>
        public override void Use()
        {
            ActingManager.instance.UseArmorItem(this);
        }
    }
}