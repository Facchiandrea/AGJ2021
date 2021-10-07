using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilastroccaUI : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public void ClickFilastrocca()
    {
        if (dialogueManager.inDialogue == false)
        {
            dialogueManager.dialogue.sentences.Clear();
            dialogueManager.sentences.Clear();
            dialogueManager.dialogue.names.Clear();
            dialogueManager.names.Clear();

            dialogueManager.dialogue.names.Add("Artemisia");
            dialogueManager.dialogue.names.Add("Artemisia");
            dialogueManager.dialogue.names.Add("Artemisia");

            dialogueManager.dialogue.sentences.Add("''In a distant time long ago,\na man tried to soar from a château.''");
            dialogueManager.dialogue.sentences.Add("''He sought what shines with its own light\nin the darkness of the night.''");
            dialogueManager.dialogue.sentences.Add("''But when he flew above the sea,\nhe realized how many things he could see.''");


            dialogueManager.StartDialogue(dialogueManager.dialogue);
            dialogueManager.DisplayNextSentence();

        }

    }
}
