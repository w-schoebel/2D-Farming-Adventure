/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 3
 * 
 * Item that is serializable and can be saved with the save manager
 */
using Assets.Enums;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
    /// <summary>
    /// Item that is serializable and can be saved with the save manager
    /// </summary>
    [System.Serializable]
    public class ItemForSave
    {
        //for ArmorItem
        public int armorValue;
        public ArmorType armor_Type;

        //forWeaponItem
        public int enduranceValue;

        //for Armor and WeaponItem
        public int damageValue;


        //for All
        public string itemName;

        public String path;
        public String childName;

        public bool isDefaultItem;
        public ItemType itemType;

        /// <summary>
        /// Extract the Sprite name and location 
        /// </summary>
        /// <returns></returns>
        public void SetSprite(Sprite icon)
        {
            this.path = AssetDatabase.GetAssetPath(icon);
            this.childName = icon.name;
        }

        /// <summary>
        /// Gets the Sprite by name and location of parent sprite
        /// </summary>
        /// <returns></returns>
        public Sprite GetSprite()
        {
            Sprite result = null;
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(this.path).OfType<Sprite>().ToArray();
            for (int i = 0; i < sprites.Length; i++)
            {
                if (sprites[i].name == this.childName)
                {
                    result = sprites[i];
                    break;
                }
            }
            return result;
        }
    }
}
