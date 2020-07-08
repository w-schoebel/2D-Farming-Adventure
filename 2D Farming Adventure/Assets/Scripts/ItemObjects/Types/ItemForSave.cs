using Assets.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.ItemObjects.Types
{
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


        public void SetSprite(Sprite icon)
        {
            this.path = AssetDatabase.GetAssetPath(icon);
            this.childName = icon.name;
        }

        public Sprite GetSprite()
        {
            Sprite result = null;
            Sprite[] sprites = AssetDatabase.LoadAllAssetsAtPath(this.path).OfType<Sprite>().ToArray();
            for(int i = 0; i < sprites.Length; i++)
            {
                if(sprites[i].name == this.childName)
                {
                    result = sprites[i];
                    break;
                }
            }
            return result;
        }
    }
}
