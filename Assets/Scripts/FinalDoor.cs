using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalDoor : MonoBehaviour
{
    public GameObject fade;
    private Animator animator;

    private void OnMouseDown()
    {
        fade.SetActive(true);
        animator = fade.GetComponent<Animator>();
        StartCoroutine(StartAnimation());
    }

    IEnumerator StartAnimation()
    {
        animator.Play("Fade_In");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
