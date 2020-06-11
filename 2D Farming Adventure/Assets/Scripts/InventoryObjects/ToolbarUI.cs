using TMPro;
using UnityEngine;

namespace Assets.Scripts.InventoryObjects
{
    public class ToolbarUI : MonoBehaviour
    {
        public Transform itemsParent;
        public GameObject toolbar_UI;

        ToolbarManager toolbar;
        ToolbarSlot[] toolbarSlots;
        TextMeshProUGUI[] textMesh;


        // Start is called before the first frame update
        void Start()
        {
            toolbar = ToolbarManager.instance;
            toolbar.itemChangedCallback += UpdateUI; //Event that triggers UpdateUI

            toolbarSlots = itemsParent.GetComponentsInChildren<ToolbarSlot>();
            textMesh = GetComponentsInChildren<TextMeshProUGUI>();
            UpdateTMP();
            Debug.Log(toolbarSlots.Length);
        }

        // Update is called once per frame
        void Update()
        {
            if(toolbarSlots != null)
            {
                KeyPressed();
            }
        }

        void UpdateUI()
        {
            for (int i = 0; i < toolbarSlots.Length; i++)
            {
                if (i < toolbar.items.Count)
                {
                    toolbarSlots[i].AddItem(toolbar.items[i]);
                }
                else
                {
                    toolbarSlots[i].ClearSlot();
                }
            }
        }

        /// <summary>
        /// if any number key is pressed the item in the corresponding slot will be used
        /// </summary>
        void KeyPressed()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0)){
                toolbarSlots[9].UseItem();
                Debug.Log("pressed: 0");
                return; //return to stop checking if any other key is pressed
            }
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                toolbarSlots[0].UseItem();
                Debug.Log("pressed: 1");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                toolbarSlots[1].UseItem();
                Debug.Log("pressed: 2");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                toolbarSlots[2].UseItem();
                Debug.Log("pressed: 3");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                toolbarSlots[3].UseItem();
                Debug.Log("pressed: 4");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                toolbarSlots[4].UseItem();
                Debug.Log("pressed: 5");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                toolbarSlots[5].UseItem();
                Debug.Log("pressed: 6");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                toolbarSlots[6].UseItem();
                Debug.Log("pressed: 7");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                toolbarSlots[7].UseItem();
                Debug.Log("pressed: 8");
                return;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                toolbarSlots[8].UseItem();
                Debug.Log("pressed: 9");
                return;
            }
        }
        private void UpdateTMP()
        {
            int slotNumber;
            for(int i=0; i < textMesh.Length; i++)
            {
                if (textMesh[i].name == "ToolSlotNR")
                {
                    slotNumber = i+1;
                    if (i == 9)
                    {
                        slotNumber = 0;
                    }
                    textMesh[i].text = slotNumber.ToString();
                }
            }
        }

    }
}
