/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 6
 * 
 * Specific consumable itemtype
 */
using Assets.Enums;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /// <summary>
    /// Specific consumable itemtype 
    /// </summary>
    /*CreateAssetMenu -> tell Unity how to create new Items (fileName is the default file Name, 
      menuName is the path where we are going to navigate in order to create the item)*/
    [CreateAssetMenu(fileName = "New Item", menuName = "Invntory/ConsumableItem")]
    public class ConsumableItem : Item
    {
        public ConsumableItem()
        {
            itemType = ItemType.Consumable;
        }

        /// <summary>
        /// Handles item usage
        /// </summary
        public override void Use()
        {
            ActingManager.instance.UseConsumableItem(this);
        }
    }
}
