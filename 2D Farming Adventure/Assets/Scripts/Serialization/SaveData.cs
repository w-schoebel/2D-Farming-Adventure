using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Serialization
{
    [System.Serializable]
    //Classes you want saved need to be Serializable
    public class SaveData
    {
        private static SaveData _current;
        public static SaveData current
        {
            get
            {
                if (_current == null)
                {
                    _current = new SaveData();
                }
                return _current;
            }

            set
            {
                if (value != null)
                {
                    _current = value;
                }

            }

        }

        public PlayerProfile profile;
       
        /*public int playerMain;
        public int playerNPC;
        public int playerEnemy;
        */

        public List<PlayerData> playerMain;
    }
}