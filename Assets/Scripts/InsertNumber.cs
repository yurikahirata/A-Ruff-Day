using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsertNumber : MonoBehaviour
{
    private KeyPad keypad;
    public GameObject number;
    public GameObject keyPad;
    public GameObject safeDoor;

    private AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        keypad = GameObject.FindGameObjectWithTag("KeyPad").GetComponent<KeyPad>();
        source = GameObject.FindGameObjectWithTag("canvas").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void KeyClicked()
    {
        for (int i = 0; i < keypad.isFull.Length; i++)
        {
            if (keypad.isFull[i] == false)
            {
                source.PlayOneShot(clip);
                // Add item
                keypad.isFull[i] = true;
                Instantiate(number, keypad.keySpaces[i].transform, false);
                break;
            }
        }
    }

    public void DeleteNumber()
    {
        for (int i = keypad.keySpaces.Length-1; i >= 0; i--)
        {
            if (keypad.isFull[i]==true)
            {
                Destroy(keypad.keySpaces[i].transform.GetChild(0).gameObject);
                keypad.isFull[i] = false;
                break;
            }
        }
    }

    public void TryPassword()
    {
        string password = "";

        if (keypad.isFull[keypad.keySpaces.Length-1] == true)
        {
            for (int i = 0; i < keypad.keySpaces.Length; i++)
            {
                password += keypad.keySpaces[i].transform.GetChild(0).tag;
            }

            if (password == "042223")
            {
                source.PlayOneShot(clip);
                Destroy(keyPad);
                Destroy(safeDoor);
            } else
            {
                for (int i = 0; i < keypad.keySpaces.Length; i++)
                {
                    Destroy(keypad.keySpaces[i].transform.GetChild(0).gameObject);
                    keypad.isFull[i] = false;
                }
            }

        } else
        {
            for (int i = 0; i < keypad.keySpaces.Length; i++)
            {
                if (keypad.keySpaces[i].transform.childCount > 0)
                    Destroy(keypad.keySpaces[i].transform.GetChild(0).gameObject);
                keypad.isFull[i] = false;
            }
        }
    }

    public void CloseWindow()
    {
        keyPad.SetActive(false);
    }

}
