using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Stats
{
    public class HealthBar : MonoBehaviour
    {
        public Slider slider;

        #region Singleton

        public static HealthBar instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of HealthBar found!");
                return;
            }
            instance = this;
        }

        #endregion

        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }

        public void SetHealth(int health)
        {
            slider.value = health;
        }
    }
}
