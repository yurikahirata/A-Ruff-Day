using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public string openedBy;
    private Inventory inventory;
    public GameObject picksUp;
    public GameObject creates;
    private bool isCorrect;
    private Dialogue dialogue;
    public int dRight;
    public int dWrong;

    private int selected;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dialogue = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Dialogue>();
        isCorrect = false;
        selected = -1;
    }

    private void OnMouseDown()
    {


        // Check if any items are selected
        for (int i = 0; i < inventory.isSelected.Length; i++)
        {
            // If right item is selected

            if (inventory.isSelected[i] == true && inventory.slots[i].transform.GetChild(0).CompareTag(openedBy))
            {
                isCorrect = true;
                dialogue.callDialogue(dRight);

                if (picksUp != null)
                {
                    for (int j = 0; j < inventory.slots.Length; j++)
                    {
                        if (inventory.isFull[j] == false)
                        {
                            // Add item
                            inventory.isFull[j] = true;
                            Instantiate(picksUp, inventory.slots[j].transform, false);
                            inventory.slots[j].transform.GetChild(0).GetComponent<InventoryItem>().indexNumber = j;
                            break;
                        }
                    }
                }

                inventory.isFull[i] = false;
                Destroy(inventory.slots[i].transform.GetChild(0).gameObject); // Get rid of inventory item
                Destroy(this.gameObject);

                if (creates != null)
                {
                    creates.SetActive(true);
                }

            }

            if (inventory.isSelected[i] == true && (inventory.slots[i].transform.GetChild(0).tag == "LeftMitten" || inventory.slots[i].transform.GetChild(0).tag == "RightMitten"))
            {
                selected = i;
            }

        }

        if (!isCorrect)
        {
            if (gameObject.tag == "tongs" && selected != -1)
            {
                dWrong = 16;
            }
            dialogue.callDialogue(dWrong);
        }

        // Reset selection
        for (int j = 0; j < inventory.isSelected.Length; j++)
        {
            if (inventory.isFull[j] == true)
                inventory.slots[j].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
            inventory.isSelected[j] = false;

        }

    }

}
