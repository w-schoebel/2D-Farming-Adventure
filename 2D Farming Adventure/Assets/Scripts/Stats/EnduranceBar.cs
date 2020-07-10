/* Author Maren Fischer, Wiebke Schöbel
 * Created at 03.06.2020
 * Version 7
 * 
 * DataObject for the endurance bar
 */
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Stats
{
    /// <summary>
    /// DataObject for the endurance bar
    /// </summary>
    public class EnduranceBar : MonoBehaviour
    {
        public Slider slider;

        #region Sigleton

        public static EnduranceBar instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of EnduranceBar found!");
                return;
            }
            instance = this;
        }

        #endregion

        public void SetMaxEndurance(int endurance)
        {
            slider.maxValue = endurance;
        }

        public void SetEndurance(int endurance)
        {
            slider.value = endurance;
        }
    }
}
