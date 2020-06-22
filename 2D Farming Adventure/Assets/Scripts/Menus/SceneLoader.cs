using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{
    public class SceneLoader : MonoBehaviour
    {
        public Animator transition;

        public float transitionTime = 1f;

        

     
        public void LoadScene0()
         {
            
            StartCoroutine(SceneLoad(0));
         }

        public void LoadScene1()
        {
            StartCoroutine(SceneLoad(1));
        }

        public void LoadScene2()
        {
            StartCoroutine(SceneLoad(2));
            
        }


        IEnumerator SceneLoad(int sceneIndex)
        {
            //animation
            transition.SetTrigger("Start");

            //wait
             yield return new WaitForSeconds(transitionTime);
            //load scene

            SceneManager.LoadScene(sceneIndex);
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
