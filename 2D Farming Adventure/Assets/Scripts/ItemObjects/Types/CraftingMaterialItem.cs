using Assets.Enums;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /*CreateAssetMenu -> tell Unity how to create new Items (fileName is the default file Name, 
      menuName is the path where we are going to navigate in order to create the item)*/
    [CreateAssetMenu(fileName = "New Item", menuName = "Invntory/CraftingMaterialItem")]
    public class CraftingMaterialItem : Item
    {
        public CraftingMaterialItem()
        {
            itemType = ItemType.CraftMaterial;
        }
    }
}
