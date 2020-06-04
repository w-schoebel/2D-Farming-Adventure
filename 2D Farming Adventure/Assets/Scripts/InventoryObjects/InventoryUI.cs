using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
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
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Inventory"))
            {
                inventory_UI.SetActive(!inventory_UI.activeSelf);
            }
        }

        void UpdateUI()
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (i < inventory.items.Count)
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
