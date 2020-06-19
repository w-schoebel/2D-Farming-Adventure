﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;

 namespace Assets.Scripts.Serialization
{
    public class Vector2SerializationSurrogate : ISerializationSurrogate
    {
        public void GetObjData(object obj, SerializationInfo info, StreamingContext context)
        {
            Vector2 v2 = (Vector2)obj;
            info.AddValue("x", v2.x);
            info.AddValue("y", v2.y);
          
        }

        public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
        {
            throw new System.NotImplementedException();
        }

        public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
        {
            Vector2 v2 = (Vector2)obj;
            v2.x = (float)info.GetValue("x", typeof(float));
            v2.y = (float)info.GetValue("y", typeof(float));
            obj = v2;
            return obj;
        }
    }
}
