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
        //public Vector3 position;
        //so store this in an array
        public float[] position;

        public PlayerData (CharacterStats player)
        {
            //variables from CharacterStats-Script
            playerName = player.name;
            health = player.currentHealth;
            endurance = player.currentEndurance;
            armor = player.armor;

            position = new float[2];
            position[0] = player.transform.position.x;
            position[1] = player.transform.position.y;
        }

      

    }
}