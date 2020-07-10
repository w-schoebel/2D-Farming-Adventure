/* Author Wiebke Schöbel
 * Created at 08.07.2020
 * Version 3
 * 
 * Interface for the save and load functionality for playerData
 */
using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Services
{
    /// <summary>
    /// Interface for the save and load functionality for playerData
    /// </summary>
    public interface SaveLoadService
    {
        /// <summary>
        /// Prepares the Items for Saving and saves the given playerData with the given current position
        /// </summary>
        /// <param name="playerData"></param>
        /// <param name="currentPosition"></param>
        void SavePlayer(PlayerData playerData, Vector2 vector2);

        /// <summary>
        /// Loads the playerData. move the rigidbody and updates the ui elements from time, toolbar, inventory and equipment
        /// </summary>
        /// <param name="rigidbody"></param>
        /// <returns></returns>
        PlayerData LoadPlayer(Rigidbody2D rigidbody);

        /// <summary>
        /// Creates a new game with standard values and save the data
        /// </summary>
        /// <param name="id"></param>
        /// <param name="playerName"></param>
        /// <param name="maxHealth"></param>
        /// <param name="maxEndurance"></param>
        /// <returns></returns>
        PlayerData NewGame(int id, string playerName, int maxHealth, int maxEndurance);

        /// <summary>
        /// Calls the save player function
        /// </summary>
        /// <param name="playerData"></param>
        void Save(PlayerData playerData);

        /// <summary>
        /// Calls the load player function
        /// </summary>
        /// <returns></returns>
        PlayerData Load();

        /// <summary>
        /// Calls the CheckIfLoadable function 
        /// </summary>
        /// <returns></returns>
        bool CheckIfLoadable();
    }
}
