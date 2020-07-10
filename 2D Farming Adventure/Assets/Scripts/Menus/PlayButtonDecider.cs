/**
* 
* 
*  Handles Button state for existing save games
*/

using Assets.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menus
{
    /// <summary>
    /// Handles Button state for existing save games
    /// </summary>
    public class PlayButtonDecider : MonoBehaviour
    {
        public GameObject button;

        private SaveLoadService saveLoadService;
        
        /// <summary>
        /// Set Button interactable false if save game not loadable
        /// </summary>
        private void Awake()
        {
            saveLoadService = new SaveLoadServiceImpl();

            if (!saveLoadService.CheckIfLoadable())
            {
                Button buttonObject = button.GetComponent<Button>();
                buttonObject.interactable = false;
            }
        }
    }
}
