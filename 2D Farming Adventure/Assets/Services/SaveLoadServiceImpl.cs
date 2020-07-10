/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 3
 *
 * Handles the save and load functionality for playerData
 */
using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects;
using Assets.Scripts.ItemObjects.Types;
using Assets.Scripts.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Services
{
    /// <summary>
    /// Handles the save and load functionality for playerData
    /// </summary>
    public class SaveLoadServiceImpl : SaveLoadService
    {
        public static SaveLoadServiceImpl Create()
        {
            return new SaveLoadServiceImpl();
        }

        /// <summary>
        /// Prepares the Items for Saving and saves the given playerData with the given current position
        /// </summary>
        /// <param name="playerData"></param>
        /// <param name="currentPosition"></param>
        public void SavePlayer(PlayerData playerData, Vector2 currentPosition)
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
            position[0] = currentPosition.x;
            position[1] = currentPosition.y;

            playerData.position = position;
            playerData.armor = armor;
            playerData.playerTimeData = playerTimeData;
            playerData.currentEquipment = currentEquipmentForSave;
            playerData.toolbarItems = toolBarItemsForSave;
            playerData.inventoryItems = inventoryItemsForSave;

            Save(playerData);
        }

        /// <summary>
        /// Converts items to itemsForSave as preparation for save
        /// </summary>
        /// <param name="items"></param>
        /// <param name="itemForSaveConverter"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Loads the playerData. move the rigidbody and updates the ui elements from time, toolbar, inventory and equipment
        /// </summary>
        /// <param name="rigidbody"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Moves the rigidbody to the given position
        /// </summary>
        /// <param name="rigidbody"></param>
        /// <param name="position"></param>
        private void SetPosition(Rigidbody2D rigidbody, float[] position)
        {
            rigidbody.position = new Vector2(position[0], position[1]);
        }

        /// <summary>
        /// Overrides the ui time with the given time
        /// </summary>
        /// <param name="playerTimeData"></param>
        private void SetTimeValue(PlayerTimeData playerTimeData)
        {
            DisplayTime.instance.SetCurrentPlayerTimeData(playerTimeData);
        }

        /// <summary>
        /// Load the items into the toolbar
        /// </summary>
        /// <param name="items"></param>
        /// <param name="itemForSaveConverter"></param>
        private void LoadToolbarItems(ItemForSave[] items, ItemForSaveConverter itemForSaveConverter)
        {
            if (items == null)
            {
                return;
            }

            if (ToolbarManager.instance != null)
            {
                ToolbarManager.instance.items = new Item[items.Length];

                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        ToolbarManager.instance.Add(itemForSaveConverter.ConvertFromItemForSave(items[i]), i, -1);
                    }
                }
            }
        }

        /// <summary>
        /// Load the items into the inventory
        /// </summary>
        /// <param name="items"></param>
        /// <param name="itemForSaveConverter"></param>
        private void LoadInventoryItems(ItemForSave[] items, ItemForSaveConverter itemForSaveConverter)
        {
            if (items == null)
            {
                return;
            }

            if (Inventory.instance != null)
            {
                Inventory.instance.items = new Item[items.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        Inventory.instance.Add(itemForSaveConverter.ConvertFromItemForSave(items[i]), i, -1);
                    }
                }
            }
        }

        /// <summary>
        /// Load the items into the equipment
        /// </summary>
        /// <param name="items"></param>
        /// <param name="itemForSaveConverter"></param>
        private void LoadCurrentEquipment(ItemForSave[] items, ItemForSaveConverter itemForSaveConverter)
        {
            if (items == null)
            {
                return;
            }

            if (EquipmentManager.instance != null)
            {
                EquipmentManager.instance.currentEquipment.Clear();
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != null)
                    {
                        EquipmentManager.instance.Equip((ArmorItem)itemForSaveConverter.ConvertFromItemForSave(items[i]), true);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a new game with standard values and save the data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="playerName"></param>
        /// <param name="maxHealth"></param>
        /// <param name="maxEndurance"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Calls the save player function
        /// </summary>
        /// <param name="playerData"></param>
        public void Save(PlayerData playerData)
        {
            SaveSystem.SavePlayer(playerData);
            Debug.Log("Saving");
        }

        /// <summary>
        /// Calls the load player function
        /// </summary>
        /// <returns></returns>
        public PlayerData Load()
        {
            return SaveSystem.LoadPlayer();
        }

        /// <summary>
        /// Calls the CheckIfLoadable function 
        /// </summary>
        /// <returns></returns>
        public bool CheckIfLoadable()
        {
            return SaveSystem.CheckIfLoadable();
        }
    }
}
