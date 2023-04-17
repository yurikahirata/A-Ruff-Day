using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public bool[] isSelected;

    private void Start()
    {
        isSelected = new bool[6];
        for (int i = 0; i < isSelected.Length; i++)
        {
            isSelected[i] = false;
        }

    }

    
}
