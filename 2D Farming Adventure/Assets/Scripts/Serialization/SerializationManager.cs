﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.Scripts.Serialization
{
    public class SerializationManager
    {
        public static bool Save(string saveName, object saveData)
        {
            BinaryFormatter formatter = GetBinaryFormatter();
            if (Directory.CreateDirectory(Application.persistentDataPath + "/tests") != null)
            {
                Directory.CreateDirectory(Application.persistentDataPath + "/tests");
            }
            string path = Application.persistentDataPath + "/tests/" + saveName + ".save";
            FileStream file = File.Create(path);
            formatter.Serialize(file, saveData);
            file.Close();
            return true;
        }

        public static object Load(string path)
        {
            if (!File.Exists(path))
            {
                return null;
            }
            BinaryFormatter formatter = GetBinaryFormatter();
            FileStream file = File.Open(path, FileMode.Open);
            try
            {
                object save = formatter.Deserialize(file);
                file.Close();
                return save;
            }
            catch
            {
                Debug.LogErrorFormat("Failed to load file at {0}", path);
                file.Close();
                return null;
            }
        }

        public static BinaryFormatter GetBinaryFormatter()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            SurrogateSelector selector = new SurrogateSelector();

            Vector2SerializationSurrogate vector2Surrogate = new Vector2SerializationSurrogate();

            selector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2Surrogate);

            formatter.SurrogateSelector = selector;

            return formatter;
        }
    }
}