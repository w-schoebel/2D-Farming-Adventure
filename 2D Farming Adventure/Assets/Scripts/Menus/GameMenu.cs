using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
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
