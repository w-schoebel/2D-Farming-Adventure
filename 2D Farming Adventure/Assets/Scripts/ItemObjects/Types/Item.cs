using Assets.Enums;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    public class Item : ScriptableObject
    {
        public string item_name = "New Item";
        public Sprite icon = null;
        public bool isDefaultItem = false;
        public ItemType itemType;

        public virtual void Use()
        {

        }
    }
}
