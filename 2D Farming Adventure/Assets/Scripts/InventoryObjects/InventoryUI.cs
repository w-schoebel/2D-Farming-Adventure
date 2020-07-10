/* Author Wiebke Schöbel
 * Created at 03.06.2020
 * Version 8
 * 
 * Controls the ui for the inventory
 */
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    /// <summary>
    /// Controls the ui for the inventory
    /// </summary>
    public class InventoryUI : MonoBehaviour
    {
        public Transform itemsParent;
        public GameObject inventory_UI;

        Inventory inventory;
        InventorySlot[] inventorySlots;

        // Start is called before the first frame update
        void Start()
        {
            inventory = Inventory.instance;
            inventory.itemChangedCallback += UpdateUI; //Event that triggers UpdateUI

            inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();

            SetSlotNumbers();
            UpdateUI();
        }

        /// <summary>
        /// Sets numbers for all slots
        /// </summary>
        private void SetSlotNumbers()
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                inventorySlots[i].SetSlotNumber(i);
            }
        }

        /// <summary>
        /// Shows the overlay for the inventory if button is pressed
        /// </summary>
        void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                inventory_UI.SetActive(!inventory_UI.activeSelf);
            }
        }

        /// <summary>
        /// Updates the ui with all items 
        /// </summary>
        void UpdateUI()
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventory.items[i] != null)
                {
                    inventorySlots[i].AddItem(inventory.items[i]);
                }
                else
                {
                    inventorySlots[i].ClearSlot();
                }
            }
        }
    }
}
