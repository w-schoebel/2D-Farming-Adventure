using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

namespace Assets.Scripts.Serialization
{
    public class SaveManager : MonoBehaviour
    {
        public TMP_InputField saveName;
        public GameObject loadButtonPrefab;

        public void OnSave()
        {
            //save game as name after input
            SerializationManager.Save(saveName.text, SaveData.current);
        }

        public string[] saveFiles;
        public void GetLoadFile()
        {
            //Directory of all saving files
            if (!Directory.Exists(Application.persistentDataPath + "/saves/"))
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/saves/");
            }
            saveFiles = Directory.GetFiles(Application.persistentDataPath + "/saves/");
        }
    }
}
