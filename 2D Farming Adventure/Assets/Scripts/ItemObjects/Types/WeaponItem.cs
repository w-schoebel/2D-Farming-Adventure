/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 8
 * 
 * Specific weapon itemtype
 */
using Assets.Enums;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /// <summary>
    /// Specific weapon itemtype 
    /// </summary>
    /*CreateAssetMenu -> tell Unity how to create new Items (fileName is the default file Name, 
      menuName is the path where we are going to navigate in order to create the item)*/
    [CreateAssetMenu(fileName = "New Item", menuName = "Invntory/WeaponItem")]
    public class WeaponItem : Item
    {
        [SerializeField]
        private int damageValue;

        [SerializeField]
        private int enduranceValue;
        public WeaponItem()
        {
            itemType = ItemType.Weapon;
        }

        /// <summary>
        /// Handles item usage
        /// </summary>
        public override void Use()
        {
            ActingManager.instance.UseWeapon(this);
        }

        public int GetDamage()
        {
            return damageValue;
        }

        public int GetEndurance()
        {
            return enduranceValue;
        }

        public void SetDamage(int damageValue)
        {
            this.damageValue = damageValue;
        }
        public void SetEndurance(int enduranceValue)
        {
            this.enduranceValue = enduranceValue;
        }
    }
}
