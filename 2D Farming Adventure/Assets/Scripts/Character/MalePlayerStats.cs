using UnityEngine;

namespace Assets.Scripts.Character
{
    public class MalePlayerStats : PlayerStats
    {
        #region Singleton

        public static MalePlayerStats instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of MalePlayerStats found!");
                return;
            }
            instance = this;
            base.Init();
        }

        #endregion
    }
}
