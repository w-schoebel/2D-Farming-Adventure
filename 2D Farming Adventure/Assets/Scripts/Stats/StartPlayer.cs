using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Assets.Scripts.Stats
{
    public class StartPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //ganmeobject which includes the script will not be destroyed
            DontDestroyOnLoad(gameObject);
            //if a new scene has been loaded
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            //check what scene have been loaded
            if (scene.name == "Title")
            {
                //don´t even load it again
                SceneManager.sceneLoaded -= OnSceneLoaded;
                //destroy, because we dont need the user interface
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
                //gameObject.SetActive(scene.name == "Battle");
            }
        }


    }
}