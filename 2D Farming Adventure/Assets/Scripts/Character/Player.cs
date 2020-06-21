using Assets.Scripts.ItemObjects;
using UnityEngine;

namespace Assets.Scripts.Character
{
    public class Player : MonoBehaviour
    {
        Interactable element;
        Transform player;
        Camera cam;
        private int maxHealth = 100;
        private int health;
        private int maxEndurance = 150;
        private int endurance;
        private int armor;
        private string playerName;
        private Vector2 position;

        private void Start()
        {
            cam = Camera.main;
            player = GetComponent<Transform>();
            element = GetComponent<Interactable>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }

        void SetFocus(Interactable newFocus)
        {
            if (newFocus != element)
            {
                element.OnDefocused();
                element = newFocus;
            }

            newFocus.OnFocused(player);
        }

        public void RemoveFocus()
        {
            if (element != null)
            {
                element.OnDefocused();
            }

            element = null;
        }
    }
}
