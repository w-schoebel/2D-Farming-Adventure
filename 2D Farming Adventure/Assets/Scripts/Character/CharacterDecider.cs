/* Author Wiebke Schöbel
 * Created at 10.06.2020
 * Version 1
 * 
 * Save the selected character in PlayerData
 * After selecting the character, the unselected character is destroyed
 */
using Assets.Scripts.Data;
using Assets.Services;
using UnityEngine;

namespace Assets.Scripts.Character
{
    
    public class CharacterDecider : MonoBehaviour
    {
        public GameObject male;
        public GameObject female;
        private SaveLoadService saveLoadService;

        #region Singleton

        public static CharacterDecider instance; //static variable is shared by all instances of a class

        /// <summary>
        /// setting the instance equal to this particular component
        /// </summary>
        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of CharacterDecider found!");
                return;
            }
            instance = this;

            saveLoadService = new SaveLoadServiceImpl();

            PlayerData playerData = saveLoadService.Load();

            if (playerData.loadNextAsNewGame)
            {
                CreateNewGame(playerData);
            }
            else
            {
                LoadExistingGame(playerData);
            }
        }

        #endregion

        public void CreateNewGame(PlayerData playerData)
        {

            switch (playerData.playerId)
            {
                case 1:
                    Destroy(female);
                    male.SetActive(true);
                    MalePlayerStats.instance.NewGame(playerData);
                    break;
                case 2:
                    Destroy(male);
                    female.SetActive(true);
                    FemalePlayerStats.instance.NewGame(playerData);
                    break;
            }
        }

        public void LoadExistingGame(PlayerData playerData)
        {
            switch (playerData.playerId)
            {
                case 1:
                    Destroy(female);
                    male.SetActive(true);
                    MalePlayerStats.instance.LoadPlayer();
                    break;
                case 2:
                    Destroy(male);
                    female.SetActive(true);
                    FemalePlayerStats.instance.LoadPlayer();
                    break;
            }
        }

        public GameObject GetCurrentCharacter()
        {
            if (female != null && female.activeSelf)
            {
                return female;
            }
            else if (male != null && male.activeSelf)
            {
                return male;
            }
            else
            {
                return null;
            }
        }

        public PlayerStats GetCurrentCharacterPlayerStats()
        {
            if (female != null && female.activeSelf)
            {
                return FemalePlayerStats.instance;
            }
            else if (male != null && male.activeSelf)
            {
                return MalePlayerStats.instance;
            }
            else
            {
                return null;
            }
        }
    }
}
