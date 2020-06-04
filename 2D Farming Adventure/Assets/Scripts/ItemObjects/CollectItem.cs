using Assets.Scripts.Character;
using Assets.Scripts.InventoryObjects;

namespace Assets.Scripts.ItemObjects
{
    public class CollectItem : Interactable
    {
        public override void Interact()
        {
            Collect();
        }

        private void Collect()
        {
            bool wasCollected = Inventory.instance.Add(item);
            if (wasCollected)
            {
                Destroy(gameObject);
            }

            Player player = new Player();
            player.RemoveFocus();
        }
    }
}
