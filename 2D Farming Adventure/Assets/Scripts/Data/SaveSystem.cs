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
       
        public static void SavePlayer(CharacterStats manager)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            //Create save File
            string path = Application.persistentDataPath + "/player.save";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(manager);

            //write data into file
            formatter.Serialize(stream, data);
            stream.Close();
            Debug.Log("Saved File");
           
        }

       

        public static PlayerData LoadPlayer ()
        {
            string path = Application.persistentDataPath + "/player.save";
            //existing check
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                Debug.Log("Save File opened");

                //from binary to read able and safe in variable (fomating in playerData)
                PlayerData data = formatter.Deserialize(stream) as PlayerData;
                Debug.Log(data);
                stream.Close();

                Debug.Log("Save File found");
                
                return data;

            } else
            {
                Debug.Log("Save File not found!");
                return null;
            }
        }
    }
}
