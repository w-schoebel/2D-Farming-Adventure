/* Author Maren Fischer
 * Created at 24.06.2020
 * Version 1
 * 
 * load the respective scene with a transition or close the game
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{

    //loading of the individual scenes
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


        //end the game and close it
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
