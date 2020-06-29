using UnityEngine;

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
            player2Renderer = player2.GetComponent<SpriteRenderer>();
        }


        public void NextCharacter()
        {
            switch (characterInt)
            {
                case 1:
                    //disable Player 1 and move him to the OffScreenPosition
                    player1Renderer.enabled = false;
                    player1.transform.position = offScreen;
                    //enable player 2 after move him to the characterPosition
                    player2.transform.position = characterPosition;
                    player2Renderer.enabled = true;
                    characterInt++;
                    break;
                case 2:
                    player2Renderer.enabled = false;
                    player2.transform.position = offScreen;
                    //enable player 2 after move him to the characterPosition
                    player1.transform.position = characterPosition;
                    player1Renderer.enabled = true;
                    characterInt++;
                    break;
                default:
                    ResetInt();
                    break;
            }

        }

        public void PeviousCharacter()
        {
            switch (characterInt)
            {
                case 1:
                    //disable Player 1 and move him to the OffScreenPosition
                    player1Renderer.enabled = false;
                    player1.transform.position = offScreen;
                    //enable player 2 after move him to the characterPosition
                    player2.transform.position = characterPosition;
                    player2Renderer.enabled = true;
                    ResetInt();
                    break;
                case 2:
                    player2Renderer.enabled = false;
                    player2.transform.position = offScreen;
                    //enable player 2 after move him to the characterPosition
                    player1.transform.position = characterPosition;
                    player1Renderer.enabled = true;
                    characterInt--;
                    break;
                default:
                    ResetInt();
                    break;
            }
        }

        private void ResetInt()
        {
            if (characterInt >= 2)
            {
                //erstes
                characterInt = 1;
            }
            else
            {
                //letztes
                characterInt = 2;
            }
        }

        public int GetChoosenCharacterID()
        {
            if (player1Renderer == enabled)
            {
                return 1;
            }
            else if(player2Renderer == enabled)
            {
                return 2;
            }
            else
            {
                Debug.Log("No Character choosed!");
                return 0;
            }
        }
    }

}
