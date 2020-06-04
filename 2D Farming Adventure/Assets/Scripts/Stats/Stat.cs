using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Stats
{
    [System.Serializable]
    public class Stat
    {
        public int baseValue;

        public int GetValue()
        {
            return baseValue;
        }
    }
}
