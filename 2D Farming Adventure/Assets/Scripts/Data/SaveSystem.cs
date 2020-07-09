/* Author Maren Fischer, Wiebke Schöbel
 * Created at 11.06.2020
 * Version 2
 * 
 * saving system for playerdata and time
 */
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Data
{

    public static class SaveSystem
    {

        //fixed path and procedure for storing the data
        public static void SavePlayer(PlayerData data)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            if (!Directory.Exists(Application.persistentDataPath + "/saving"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saving");
            }
            string path = Application.persistentDataPath + "/saving/game.save";

            FileStream stream = new FileStream(path, FileMode.Create);

            //write data into file
            formatter.Serialize(stream, data);
            stream.Close();

            Debug.Log("Saved File");
        }

        //Specified path and sequence for loading the data
        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/saving/game.save";
            //existing check
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                // FileStream file = File.Open(path, FileMode.Open);
                FileStream stream = new FileStream(path, FileMode.Open);
                Debug.Log("Save File opened");
                try
                {
                    //from binary to read able and safe in variable (fomating in playerData)
                    PlayerData data = formatter.Deserialize(stream) as PlayerData;


                    stream.Close();


                    Debug.Log("Loaded");

                    return data;
                }
                catch
                {
                    Debug.LogErrorFormat("Failed to load file at {0}", path);

                    return null;
                }
            }
            else
            {
                Debug.Log("Save File not found!");
                return null;
            }

        }
    }
}
