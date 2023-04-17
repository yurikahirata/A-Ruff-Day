using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    private Dialogue dialogue;
    public int d; // Dialogue index

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dialogue = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Dialogue>();
    }

    private void OnMouseDown()
    {

        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == false)
            {
                // Add item to next empty inventory slot
                inventory.isFull[i] = true;
                Instantiate(itemButton, inventory.slots[i].transform, false);
                inventory.slots[i].transform.GetChild(0).GetComponent<InventoryItem>().indexNumber = i;

                dialogue.callDialogue(d);

                Destroy(gameObject);
                break;
            }
        }

    }

}
