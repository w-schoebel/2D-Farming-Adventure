using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Stats
{
    public class EnduranceBar : MonoBehaviour
    {
        public Slider slider;

        public void SetMaxEndurance(int endurance)
        {
            slider.maxValue = endurance;
            slider.value = endurance;
        }

        public void SetEndurance(int endurance)
        {
            slider.value = endurance;
        }
    }
}
