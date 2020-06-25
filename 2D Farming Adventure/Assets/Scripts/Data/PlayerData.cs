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

        public PlayerData (string playerName, int health, int armor, int endurance, float[] position, double year, double month, double day, double hour, double minute, double second)
        {
            //variables from CharacterStats-Script
          this.playerName = playerName;
          this.health = health;
          this.endurance = endurance;
          this.armor = armor;
          this.year = year;
          this.month = month;
          this.day = day;
          this.hour = hour;
          this.minute =minute;
          this.second = second;       
          this.position = position;
        }     
    }
}