using Assets.Scripts.ItemObjects.Types;
using UnityEngine;

namespace Assets.Scripts.ItemObjects
{
    public class Interactable : MonoBehaviour
    {
        public float radius = 1f; //Entfernung bis mit Item interagiert werden kann
        public Transform interaction_Transform;
        public Item item;

        bool isFocus = false;
        bool hasInteracted = false;
        Transform player;

        public virtual void Interact()
        {
            Debug.Log("Interacting with " + transform.name);
        }

        private void Update()
        {
            // if (isFocus && !hasInteracted)
            // {
            //     float distance = Vector2.Distance(player.position, interaction_Transform.position);
            //     if (distance <= radius)
            //     {
            //         Interact();
            //         Debug.Log("interacted");
            //         hasInteracted = true;
            //     }
            // }
        }

        public void OnFocused(Transform playerTransform)
        {
            isFocus = true;
            player = playerTransform;
            hasInteracted = false;
        }

        public void OnDefocused()
        {
            isFocus = false;
            player = null;
            hasInteracted = false;
        }

        private void OnDrawGizmosSelected()
        {
            if (interaction_Transform == null)
            {
                interaction_Transform = player;
            }

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.name.Contains("Player")) //maybe change to !collision.name.contains("") for the names of NPC, because user sets name of Player
            {
                Interact();
            }
        }
    }
}
