﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//für Scenen-"Arbeit" in Unity
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        //läd Szene mit aktuellem Scenenindex + 1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}