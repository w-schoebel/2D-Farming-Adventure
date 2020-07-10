/* Author Maren Fischer
 * Created at 22.06.2020
 * Version 5
 * 
 * Loads the individual scenes
 */
using Assets.Services;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Menu
{

    /// <summary>
    /// Loads the individual scenes
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        public Animator transition;

        public float transitionTime = 1f;

        /// <summary>
        /// Loads Scene 0
        /// </summary>
        public void LoadScene0()
        {
            StartCoroutine(SceneLoad(0));
        }

        /// <summary>
        /// Loads Scene 1 (if already saved once)
        /// </summary>
        public void LoadScene1()
        {
            StartCoroutine(SceneLoad(1));
        }

        /// <summary>
        /// Loads Scene 2
        /// </summary>
        public void LoadScene2()
        {
            StartCoroutine(SceneLoad(2));
        }

        /// <summary>
        /// Loads Scene for given index
        /// </summary>
        IEnumerator SceneLoad(int sceneIndex)
        {
            //animation
            transition.SetTrigger("Start");

            //wait
            yield return new WaitForSeconds(transitionTime);
            //load scene

            SceneManager.LoadScene(sceneIndex);
        }

        /// <summary>
        /// Quits the game
        /// </summary>
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
