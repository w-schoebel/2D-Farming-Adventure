/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 3
 *
 * Controls the saving and loading action for the ui
 */
using Assets.Scripts.Character;
using UnityEngine;

namespace Assets.Scripts.Data
{
    /// <summary>
    /// Controls the saving and loading action for the ui
    /// </summary>
    public class SaveLoadDecider : MonoBehaviour
    {
        /// <summary>
        /// Called to save the current state
        /// </summary>
        public void SaveCurrentCharacter()
        {
            if (CharacterDecider.instance != null)
            {
                CharacterDecider.instance.GetCurrentCharacterPlayerStats().SavePlayer();
            }
        }

        /// <summary>
        /// Called to load the existing state
        /// </summary>
        public void LoadCurrentCharacter()
        {
            if (CharacterDecider.instance != null)
            {
                CharacterDecider.instance.GetCurrentCharacterPlayerStats().LoadPlayer();
            }
        }
    }
}
