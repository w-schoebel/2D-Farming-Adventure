using Assets.Scripts.Data;
using Assets.Scripts.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace Assets.Scripts.Menu
{
    public class GameMenu : MonoBehaviour
    {

        public string playerName;
        public int health;
        public int armor;
        public int endurance;
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

       

     
        public void OpenMenu()
        {
            //läd Szene mit aktuellem Scenenindex + 1
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        
    }
}
