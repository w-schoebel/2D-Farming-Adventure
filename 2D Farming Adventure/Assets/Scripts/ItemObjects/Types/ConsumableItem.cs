using Assets.Enums;
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /*CreateAssetMenu -> tell Unity how to create new Items (fileName is the default file Name, 
      menuName is the path where we are going to navigate in order to create the item)*/
    [CreateAssetMenu(fileName = "New Item", menuName = "Invntory/ConsumableItem")]
    public class ConsumableItem : Item
    {
        public ConsumableItem()
        {
            itemType = ItemType.Consumable;
        }

        public override void Use()
        {
            ActingManager.instance.UseConsumableItem(this);
        }
    }
}
