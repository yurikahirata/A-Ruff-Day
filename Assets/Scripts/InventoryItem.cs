using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string combinesWith;
    public int indexNumber;

    public GameObject combinedProduct;

    private Inventory inventory;
    private Dialogue dialogue;
    public int dRight;
    public int dWrong;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dialogue = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Dialogue>();
        //Debug.Log(indexNumber);
    }


    public void SelectItem()
    {
        gameObject.GetComponent<Image>().color = Color.green;
        int tempCount = 0;
        int countIndex = 0;
        

        for (int j = 0; j < inventory.isSelected.Length; j++)
        {
            if (inventory.isSelected[j] == true)
            {
                tempCount++;
                countIndex = j;
            }
        }

      
        // If nothing is selected
        if (tempCount == 0)
        {
            inventory.isSelected[indexNumber] = true;
        }
        // If something else is selected
        else 
        {
            // See if they can be combined
            if (combinedProduct != null && inventory.slots[countIndex].transform.GetChild(0).gameObject.tag == combinesWith) //tag
            {
                GameObject otherGameObject = inventory.slots[countIndex].transform.GetChild(0).gameObject;
                Transform thisParent = inventory.slots[indexNumber].transform;

                Destroy(otherGameObject);
                inventory.isFull[indexNumber] = false; // Set to false so new object can be instantiated
                Instantiate(combinedProduct, thisParent, false); // Instantiate the combined product
                thisParent.GetChild(1).gameObject.GetComponent<InventoryItem>().indexNumber = indexNumber; // Set the correct index number of combined product

                
                inventory.isFull[indexNumber] = true; // set combined object slot to full
                inventory.isFull[countIndex] = false; // Set first object slot to empty

                // Reset selections
                inventory.isSelected[indexNumber] = false;
                inventory.isSelected[countIndex] = false;

                // call dialogue
                dialogue.callDialogue(dRight);

                Destroy(this.gameObject);

            } else
            {
                // call dialogue
                dialogue.callDialogue(dWrong);

                // Reset selections
                inventory.isSelected[indexNumber] = false;
                inventory.isSelected[countIndex] = false;

                inventory.slots[indexNumber].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;
                inventory.slots[countIndex].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;

            }
        }
    }

}
