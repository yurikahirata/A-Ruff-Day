using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Investigate : MonoBehaviour
{
    public GameObject investigatedObject;
    private AudioSource source;
    public AudioClip clip;

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("canvas").GetComponent<AudioSource>();
    }

    public void OnMouseDown() // For interacting with items in game scene
    {
        if (clip != null)
            source.PlayOneShot(clip);

        if (investigatedObject != null)
        {
            investigatedObject.SetActive(true);
        }

        gameObject.SetActive(false);

        if (gameObject.CompareTag("note"))
        {
            GameObject.FindGameObjectWithTag("frame").GetComponent<Unlock>().dWrong = 24;
        }
    }

    public void OnClick() // For closing components on the Canvas
    {
        if (clip != null)
            source.PlayOneShot(clip);
        investigatedObject.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
