using Assets.Scripts.Character;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Assets.Scripts.Stats;
using System;

namespace Assets.Scripts.Data
{
    
    public static class SaveSystem
    {
       
        public static void SavePlayer(CharacterStats player)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            //Create save File
            string path = Application.persistentDataPath + "/player.save";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(player);

            //write data into file
            formatter.Serialize(stream, data);
            stream.Close();
        }

       

        public static PlayerData LoadPlayer ()
        {
            string path = Application.persistentDataPath + "/player.save";
            //existing check
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                //from binary to read able and safe in variable (fomating in playerData)
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                stream.Close();
                 Debug.Log("Save File not found!");

                return data;

            } else
            {
                Debug.Log("Save File not found!");
                return null;
            }
        }
    }
}
