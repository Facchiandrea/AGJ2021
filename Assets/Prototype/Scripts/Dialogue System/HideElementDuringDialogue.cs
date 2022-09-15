using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideElementDuringDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public GameObject[] itemsToHide;

    private bool hidden;

    void Update()
    {
        if (dialogueManager.inDialogue)
        {
            foreach (var item in itemsToHide)
            {
                item.SetActive(false);
            }
            hidden = true;


        }
        else
        {
            if (hidden == true)
            {
                Invoke("HideElements", 0.4f);

            }
        }

    }

    private void HideElements()
    {
        foreach (var item in itemsToHide)
        {
            item.SetActive(true);
        }
        hidden = false;

    }
}
