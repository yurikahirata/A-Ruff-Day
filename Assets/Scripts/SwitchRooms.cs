using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchRooms : MonoBehaviour
{
    public GameObject[] rooms;
    private int cameraIndex;
    private AudioSource source;
    public AudioClip clickSound;

    void Start()
    {
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].GetComponent<Camera>().aspect = 1.78f;
        }
        cameraIndex = 1;
        source = GetComponent<AudioSource>();
    }

    public void clickLeft()
    {
        // Play click sound
        source.PlayOneShot(clickSound);

        rooms[cameraIndex].SetActive(false);
        if (cameraIndex == 0)
        {
            cameraIndex = rooms.Length - 1;
        } else
        {
            cameraIndex--;
        }

        rooms[cameraIndex].SetActive(true);
    }

    public void clickRight()
    {
        // Play click sound
        source.PlayOneShot(clickSound);

        rooms[cameraIndex].SetActive(false);
        if(cameraIndex == rooms.Length-1)
        {
            cameraIndex = 0;
        } else
        {
            cameraIndex++;
        }

        rooms[cameraIndex].SetActive(true);
    }
}
