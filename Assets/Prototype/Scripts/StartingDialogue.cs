using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingDialogue : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public bool dialogoFatto = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Activator"))
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

                dialogueManager.dialogue.sentences.Add("Hey ma dove mi trovo?\nDove ho già visto questo posto?");
                dialogueManager.dialogue.sentences.Add("Mi sembra quel quadro che tengo sopra il gabinetto...");
                dialogueManager.dialogue.sentences.Add("...hey aspetta,ma è proprio QUEL quadro!");
                dialogueManager.dialogue.sentences.Add("Come faccio ad uscire?");


                dialogueManager.StartDialogue(dialogueManager.dialogue);
                dialogueManager.DisplayNextSentence();

            }

        }
    }
}
