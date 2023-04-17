using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource source;

    private void Start()
    {
        source = GameObject.FindGameObjectWithTag("key").GetComponent<AudioSource>();
    }

    public void StartNewGame()
    {
        source.PlayOneShot(clip);
        StartCoroutine(ShowInstructions());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator ShowInstructions()
    {
        gameObject.GetComponent<Canvas>().enabled = false;

        yield return new WaitForSeconds(6);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
