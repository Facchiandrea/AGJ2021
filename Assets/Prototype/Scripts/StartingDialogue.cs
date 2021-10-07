using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool dialogoFatto = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator") && dialogoFatto == false)
        {
            dialogoFatto = true;
            if (dialogueManager.inDialogue == false)
            {
                dialogueManager.dialogue.sentences.Clear();
                dialogueManager.sentences.Clear();
                dialogueManager.dialogue.names.Clear();
                dialogueManager.names.Clear();

                dialogueManager.dialogue.names.Add("Artemisia");
                dialogueManager.dialogue.names.Add("Artemisia");
                dialogueManager.dialogue.names.Add("Artemisia");
                dialogueManager.dialogue.names.Add("Artemisia");

                dialogueManager.dialogue.sentences.Add("Yawn ... what time is it? Five more minutes...\nWait, where am I?");
                dialogueManager.dialogue.sentences.Add("I think I've seen this place before; it looks like the painting that I hung over the toilet.");
                dialogueManager.dialogue.sentences.Add("...but it's really THAT painting!");
                dialogueManager.dialogue.sentences.Add("Okay, I'm clearly in a dream. I have to find a way to wake up, but how? Maybe that guy can help me.");


                dialogueManager.StartDialogue(dialogueManager.dialogue);
                dialogueManager.DisplayNextSentence();

            }

        }
    }
}
