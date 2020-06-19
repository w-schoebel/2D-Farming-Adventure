using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Serialization
{

    public class PlayerProfile 
    {
        public string playerName;
        //public Image playerModel;
        public int armor;
        public int health;
        public int endurance;
    


      /*  public void OnLoadGame()
        {
            SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/save/Save.save");
            UpdateUI();
        }

        public  void takeDamage()
    
                SaveData.current.profile.health -= 10;
                UpdateUI;
            }
        }

        private void UpdateUI()
        {

        }*/
      }

}
