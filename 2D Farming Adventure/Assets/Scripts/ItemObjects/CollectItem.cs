/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 6
 * 
 * Collects item by player
 */
using Assets.Scripts.InventoryObjects;

namespace Assets.Scripts.ItemObjects
{
    /// <summary>
    /// Collects item by player
    /// </summary>
    public class CollectItem : Interactable
    {
        /// <summary>
        /// Handles the interact of items in scene with the player
        /// </summary>
        public override void Interact()
        {
            Collect();
        }

        /// <summary>
        /// Collects the item (destorys item in scene) and adds it to the inventory
        /// </summary>
        private void Collect()
        {
            bool wasCollected = Inventory.instance.Add(item);
            if (wasCollected)
            {
                Destroy(gameObject);
            }
        }
    }
}
