using Assets.Scripts.Data;
using Assets.Services;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.Character
{
    public class CharacterSelector : MonoBehaviour
    {
        //create a Gameobject for each sprite
        public GameObject player1;
        public GameObject player2;
        private Vector3 characterPosition;
        private Vector3 offScreen;
        private int characterInt = 1;
        private SpriteRenderer player1Renderer, player2Renderer;
        public InputField playerName;
        private SaveLoadService saveLoadService;

        #region Singleton

        public static CharacterSelector instance; //static variable is shared by all instances of a class

        #endregion

        private void Awake()
        {
            //proof that there is only one instance otherwise warn us
            if (instance != null)
            {
                Debug.LogWarning("More than one instance of PlayerStats found!");
                return;
            }
            instance = this;

            //get characterPosition
            characterPosition = player1.transform.position;

            //get offScreenPosiotion
            offScreen = player2.transform.position;

            //get each spriteRenderer
            player1Renderer = player1.GetComponent<SpriteRenderer>();
            player1Renderer.enabled = true;
            player2Renderer = player2.GetComponent<SpriteRenderer>();
            player2Renderer.enabled = false;

            saveLoadService = new SaveLoadServiceImpl();
        }

        public void NextCharacter()
        {
            switch (characterInt)
            {
                case 1:
                    enablePlayer2();
                    break;
                case 2:
                    enablePlayer1();
                    break;
                default:
                    break;
            }

        }

        private void enablePlayer2()
        {
            //disable Player 1 and move him to the OffScreenPosition
            player1Renderer.enabled = false;
            player1.transform.position = offScreen;
            //enable player 2 after move him to the characterPosition
            player2.transform.position = characterPosition;
            player2Renderer.enabled = true;
            characterInt++;
        }

        private void enablePlayer1()
        {
            player2Renderer.enabled = false;
            player2.transform.position = offScreen;
            //enable player 2 after move him to the characterPosition
            player1.transform.position = characterPosition;
            player1Renderer.enabled = true;
            characterInt--;
        }

        public void PeviousCharacter()
        {
            switch (characterInt)
            {
                case 1:
                    enablePlayer2();
                    break;
                case 2:
                    enablePlayer1();
                    break;
                default:
                    break;
            }
        }

        public int GetChoosenCharacterID()
        {
            if (player1Renderer.enabled == enabled)
            {
                return 1;
            }
            else if (player2Renderer.enabled == enabled)
            {
                return 2;
            }
            else
            {
                Debug.Log("No Character choosed!");
                return 0;
            }
        }

        public void SaveIntialInformations()
        {
            saveLoadService.Save(new PlayerData(GetChoosenCharacterID(), playerName.text, true));
        }
    }
}
