using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallDialogue : MonoBehaviour
{
    private Dialogue dialogue;
    private Inventory inventory;
    public int d; // Dialogue index
    public int d2; // Dialogue 2 index


    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        dialogue = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        dialogue.callDialogueOwn(d, d2);

        for (int i = 0; i < inventory.isSelected.Length; i++)
        {
            if (inventory.isSelected[i])
            {
                inventory.isSelected[i] = false;
                inventory.slots[i].transform.GetChild(0).gameObject.GetComponent<Image>().color = Color.white;

            }
        }
    }
}
