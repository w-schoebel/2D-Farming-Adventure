using Assets.Scripts.Data;
using Assets.Scripts.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace Assets.Scripts.Menu
{ 
public class MainMenu : MonoBehaviour
{
        public CharacterStats characterStats;
        
        public void PlayGame()
    {
            
            //läd Szene mit aktuellem Scenenindex + 2
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
      

        }
        public void NewGame()
        {

            //läd Szene mit aktuellem Scenenindex + 1
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Reset all saves


        }


        public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

       
    }
}
