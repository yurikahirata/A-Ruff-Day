using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFood : MonoBehaviour
{
    public string openedBy;
    public Inventory inventory;
    public GameObject creates;

    private Dialogue dialogue;
    public int dRight; // Index of dialogue if correct
    public int dWrong; // Index of dialogue if wrong
    public GameObject deleteFig;

    public GameObject fig;

    public GameObject finalDoor;

    private bool isCorrect;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dialogue = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Dialogue>();
        isCorrect = false;
        finalDoor.SetActive(false);
    }

    private void OnMouseDown()
    {
        // Check if any items are selected
        for (int i = 0; i < inventory.isSelected.Length; i++)
        {
            // If catfood is selected
            if (inventory.isSelected[i] == true && inventory.slots[i].transform.GetChild(0).CompareTag(openedBy))
            {
                dialogue.callDialogue(dRight);
                isCorrect = true;

                inventory.isFull[i] = false;
                Destroy(inventory.slots[i].transform.GetChild(0).gameObject); // Get rid of inventory item

                if (creates != null)
                {
                    creates.SetActive(true);
                }

                fig.SetActive(true);
                finalDoor.SetActive(true);
                Destroy(deleteFig);

            }
        }


        for (int j = 0; j < inventory.isSelected.Length; j++)
        {
            inventory.isSelected[j] = false;
        }

        if (!isCorrect)
        {
            dialogue.callDialogue(dWrong);
        }
    }
}
