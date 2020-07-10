/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 6
 * 
 * Handles interaction between player and interactable
 */
using Assets.Scripts.ItemObjects.Types;
using UnityEngine;

namespace Assets.Scripts.ItemObjects
{
    /// <summary>
    /// Handles interaction between player and interactable
    /// </summary>
    public class Interactable : MonoBehaviour
    {
        public float radius = 1f; //range for possible interaction with the player
        public Transform interaction_Transform;
        public Item item;

        /// <summary>
        /// Handles the interact of items in scene with the player
        /// </summary>
        public virtual void Interact()
        {
            Debug.Log("Interacting with " + transform.name);
        }

        /// <summary>
        /// Calls interact if player collides with interactable
        /// </summary>
        /// <param name="collision"></param>
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Contains("Player")) 
            {
                Interact();
            }
        }
    }
}
