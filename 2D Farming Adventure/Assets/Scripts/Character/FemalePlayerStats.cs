using Assets.Scripts.Data;
using Assets.Scripts.InventoryObjects;
using Assets.Scripts.ItemObjects.Types;
using Assets.Scripts.Menu;
using Assets.Scripts.Stats;
using Assets.Services;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
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
