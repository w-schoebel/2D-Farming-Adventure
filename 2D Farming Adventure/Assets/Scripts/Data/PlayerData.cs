using Assets.Scripts.Character;
using Assets.Scripts.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Data
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int health;
        public int armor;
        public int endurance;
        //serializeable will not work for:
        //public Vector2 position;
        //so store this in an array
        public float[] position;
        public double year;
        public double month;
        public double day;
        public double hour;
        public double minute;
        public double second;

        public PlayerData (PlayerStats manager)
        {
            //variables from CharacterStats-Script
            playerName = manager.playerName;
            health = manager.health;
            endurance = manager.endurance;
            armor = manager.armor;
            year = manager.year;
            month = manager.month;
            day = manager.day;
            hour = manager.hour;
            minute = manager.minute;
            second = manager.second;

            position = new float[2];
            position[0] = manager.transform.position.x;
            position[1] = manager.transform.position.y;
        }
    }
}