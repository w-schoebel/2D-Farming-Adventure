using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private void Awake()
        {
            instance = this;

            SceneManager.LoadSceneAsync((int)SceneIndexes.MENU, LoadSceneMode.Additive);
        }

        public void LoadGame()
        {
            SceneManager.UnloadSceneAsync((int)SceneIndexes.MENU);
            SceneManager.LoadSceneAsync((int)SceneIndexes.MAIN, LoadSceneMode.Additive);
        }
    }
}
