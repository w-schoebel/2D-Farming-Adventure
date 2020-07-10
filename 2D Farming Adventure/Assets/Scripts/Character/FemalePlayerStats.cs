/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 4
 * 
 * Specific instance of PlayerStats for the female character
 */
using UnityEngine;

namespace Assets.Scripts.Character
{
    /// <summary>
    /// Specific instance of PlayerStats for the female character
    /// </summary>
    public class FemalePlayerStats : PlayerStats
    {
        #region Singleton

        public static FemalePlayerStats instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of FemalePlayerStats found!");
                return;
            }
            instance = this;
            base.Init();
        }

        #endregion
    }
}
