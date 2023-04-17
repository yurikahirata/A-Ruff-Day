using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueBox;
    public GameObject dialogue;
    public GameObject dialogue2;
    public GameObject[] lines;
    private bool canStart;

    private void Start()
    {
        canStart = true;
    }

    public void callDialogueOwn(int i, int j)
    {
        if (canStart) // If other dialogue is not showing at the same time
        {
            canStart = false;
            dialogueBox.SetActive(true);
            StartCoroutine(TimerCoroutine(i, j));
        }

    }

    IEnumerator TimerCoroutine(int i, int j)
    {
        GameObject temp1 = Instantiate(lines[i], dialogueBox.transform, false); // Show dialogue

        yield return new WaitForSeconds(2);
        Destroy(temp1); // Delete dialogue

        if (j != -1) // If there is a second line, show
        {
            GameObject temp2 = Instantiate(lines[j], dialogueBox.transform, false);
            yield return new WaitForSeconds(2);
            GameObject.Destroy(temp2);
        }

        dialogueBox.SetActive(false);
        canStart = true;

    }

    public void callDialogue(int i)
    {
        if (canStart)
        {
            canStart = false;
            dialogueBox.SetActive(true);
            StartCoroutine(TimerCoroutineOutside(i));
        }

    }

    IEnumerator TimerCoroutineOutside(int i)
    {
        GameObject temp1 = Instantiate(lines[i], dialogueBox.transform, false);

        yield return new WaitForSeconds(2);
        Destroy(temp1);

        dialogueBox.SetActive(false);
        canStart = true;

    }
}
