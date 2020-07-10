/* Author Maren Fischer, Wiebke Schöbel
 * Created at 11.06.2020
 * Version 12
 * 
 * DataClass for saving/loading the character
 */
using Assets.Scripts.ItemObjects.Types;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// DataClass for saving/loading the character 
    /// </summary>
    [System.Serializable]
    public class PlayerData
    {
        public int playerId;
        public string playerName;
        public int health;
        public int armor;
        public int endurance;
        public float[] position;
        public PlayerTimeData playerTimeData;
        public ItemForSave[] currentEquipment;
        public ItemForSave[] toolbarItems;
        public ItemForSave[] inventoryItems;
        public bool loadNextAsNewGame;

        public PlayerData(int playerId, string playerName, int health, int armor, int endurance, float[] position, PlayerTimeData playerTimeData,
            ItemForSave[] currentEquipment, ItemForSave[] toolbarItems, ItemForSave[] inventoryItems, bool loadNextAsNewGame)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.health = health;
            this.endurance = endurance;
            this.armor = armor;
            this.playerTimeData = playerTimeData;
            this.currentEquipment = currentEquipment;
            this.position = position;
            this.toolbarItems = toolbarItems;
            this.inventoryItems = inventoryItems;
            this.loadNextAsNewGame = loadNextAsNewGame;
        }

        public PlayerData(int playerId, string playerName, bool loadNextAsNewGame)
        {
            this.playerId = playerId;
            this.playerName = playerName;
            this.health = -1;
            this.endurance = -1;
            this.armor = -1;
            this.playerTimeData = null;
            this.currentEquipment = null;
            this.position = null;
            this.toolbarItems = null;
            this.inventoryItems = null;
            this.loadNextAsNewGame = loadNextAsNewGame;
        }
    }
}