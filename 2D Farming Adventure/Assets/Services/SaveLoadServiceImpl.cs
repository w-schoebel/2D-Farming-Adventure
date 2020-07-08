using Assets.Scripts.Character;
using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects;
using Assets.Scripts.ItemObjects.Types;
using Assets.Scripts.Stats;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

namespace Assets.Services
{
    public class SaveLoadServiceImpl : SaveLoadService
    {
        public static SaveLoadServiceImpl Create()
        {
            return new SaveLoadServiceImpl();
        }

        public void SavePlayer(PlayerData playerData, Vector2 vector2)
        {
            PlayerTimeData playerTimeData = DisplayTime.instance.GetCurrentPlayerTimeData();
            int armor = EquipmentManager.instance.GetCurrentAmor();
            Item[] toolbarItems = ToolbarManager.instance.items;
            Item[] inventoryItems = Inventory.instance.items;
            List<ArmorItem> currentEquipment = EquipmentManager.instance.currentEquipment;

            ItemForSaveConverter itemForSaveConverter = new ItemForSaveConverter();


            ItemForSave[] toolBarItemsForSave = PrepareItemsForSave(toolbarItems, itemForSaveConverter);
            ItemForSave[] inventoryItemsForSave = PrepareItemsForSave(inventoryItems, itemForSaveConverter);
            ItemForSave[] currentEquipmentForSave = PrepareItemsForSave(currentEquipment.ToArray(), itemForSaveConverter);

            float[] position = new float[2];
            position[0] = vector2.x;
            position[1] = vector2.y;

            playerData.position = position;
            playerData.armor = armor;
            playerData.playerTimeData = playerTimeData;
            playerData.currentEquipment = currentEquipmentForSave;
            playerData.toolbarItems = toolBarItemsForSave;
            playerData.inventoryItems = inventoryItemsForSave;

            Save(playerData);
        }

        private ItemForSave[] PrepareItemsForSave(Item[] items, ItemForSaveConverter itemForSaveConverter)
        {
            int length = items.Length;
            ItemForSave[] result = new ItemForSave[length];

            for (int i = 0; i < length; i++)
            {
                result[i] = itemForSaveConverter.ConvertFromItem(items[i]);
            }

            return result;
        }

        public PlayerData LoadPlayer(Rigidbody2D rigidbody)
        {
            ItemForSaveConverter itemForSaveConverter = new ItemForSaveConverter();

            PlayerData playerData = SaveSystem.LoadPlayer();

            SetPosition(rigidbody, playerData.position);
            SetTimeValue(playerData.playerTimeData);

            LoadToolbarItems(playerData.toolbarItems, itemForSaveConverter);
            LoadInventoryItems(playerData.inventoryItems, itemForSaveConverter);
            LoadCurrentEquipment(playerData.currentEquipment, itemForSaveConverter);

            Debug.Log("Load");

            return playerData;
        }

        private void SetPosition(Rigidbody2D rigidbody, float[] position)
        {
            rigidbody.position = new Vector2(position[0], position[1]);
        }

        private void SetTimeValue(PlayerTimeData playerTimeData)
        {
            DisplayTime.instance.SetCurrentPlayerTimeData(playerTimeData);
        }

        private void LoadToolbarItems(ItemForSave[] items, ItemForSaveConverter itemForSaveConverter)
        {
            if (items == null)
            {
                return;
            }

            if (ToolbarManager.instance != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        ToolbarManager.instance.Add(itemForSaveConverter.ConvertFromItemForSave(items[i]), i, -1);
                    }
                }
            }
        }

        private void LoadInventoryItems(ItemForSave[] items, ItemForSaveConverter itemForSaveConverter)
        {
            if (items == null)
            {
                return;
            }

            if (Inventory.instance != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        Inventory.instance.Add(itemForSaveConverter.ConvertFromItemForSave(items[i]), i, -1);
                    }
                }
            }
        }

        private void LoadCurrentEquipment(ItemForSave[] items, ItemForSaveConverter itemForSaveConverter)
        {
            if (items == null)
            {
                return;
            }

            if (EquipmentManager.instance != null)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        EquipmentManager.instance.Equip((ArmorItem)itemForSaveConverter.ConvertFromItemForSave(items[i]), true);
                    }
                }
            }
        }

        public PlayerData NewGame(int id, string playerName, int maxHealth, int maxEndurance)
        {
            float[] position = new float[2];
            position[0] = 12f;
            position[1] = -1.6f;
            int playerId = id;

            PlayerData playerData = new PlayerData(playerId, playerName, maxHealth, 0, maxEndurance, position, new PlayerTimeData(1.0, 1.0, 1.0, 6.0, 0.0, 0.0), null, null, null, false);

            Save(playerData);

            return playerData;
        }

        public void Save(PlayerData playerData)
        {
            SaveSystem.SavePlayer(playerData);
            Debug.Log("Saving");
        }

        public PlayerData Load()
        {
            return SaveSystem.LoadPlayer();
        }
    }
}
