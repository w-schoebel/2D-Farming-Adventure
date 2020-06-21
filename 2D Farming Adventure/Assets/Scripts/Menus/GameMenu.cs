using Assets.Scripts.Data;
using Assets.Scripts.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;




namespace Assets.Scripts.Menu
{
    public class GameMenu : MonoBehaviour
    {

       
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

       

     
        public void OpenMenu()
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

        
    }
}
