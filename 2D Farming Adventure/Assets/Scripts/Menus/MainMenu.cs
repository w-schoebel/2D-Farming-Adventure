using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//für Scenen-"Arbeit" in Unity
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Menu
{ 
public class MainMenu : MonoBehaviour
{
        public string playerName;
        public int health;
        public int armor;
        public int endurance;
        public void PlayGame()
    {
        //läd Szene mit aktuellem Scenenindex + 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

     public void LoadPlayer()
        {
            PlayerData data = SaveSystem.LoadPlayer();
            Debug.Log("Load");

            playerName = data.playerName;
            health = data.health;
            endurance = data.endurance;
            armor = data.armor;
            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];

        }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
}
