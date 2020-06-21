using UnityEngine;

namespace Assets.Scripts.Serialization
{
    [System.Serializable]
    public enum PlayerType
    {
        Npc,
        Main,
        Enemy
    }

    [System.Serializable]
    public class PlayerData
    {
        public string id;
        public string name;
        public PlayerType playerType;
        public Vector2 position;
    }
}
