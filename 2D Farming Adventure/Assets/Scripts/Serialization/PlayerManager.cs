using Assets.Scripts.Character;
using Assets.Scripts.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Serialization
{
    public class PlayerManager : MonoBehaviour
    {
        public void OnSave()
        {
            SerializationManager.Save("playersave", SaveData.current);
        }

        public void OnLoad()
        {
            //tell the game to load (then destroy the current game object)
          //  GameEvents.current.dispatchOnLoadEvent();
            SaveData.current = (SaveData)SerializationManager.Load(Application.persistentDataPath + "/saves/playersaves.save");

            for (int i=0; i<SaveData.current.playerMain.Count; i++)
            {
                PlayerData currentPlayer = SaveData.current.playerMain[i];
               // GameObject obj = Instantiate(player[(int)currentPlayer.playerType]);
                //PlayerHandler playerHandler = obj.GetComponent<PlayerHandler>();
                //playerHandler.playerData = currentPlayer;
                //playerHandler.transform.position = currentPlayer.position;
            }
        }
    }
}
