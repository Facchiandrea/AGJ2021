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

            dialogueManager.dialogue.sentences.Add("''In a distant time long ago,\na brave man tried to soar from a château.''");
            dialogueManager.dialogue.sentences.Add("''He traveled far and wide in all the nations,\nseeing beautiful landscapes and ancient civilizations.''");
            dialogueManager.dialogue.sentences.Add("''And in the end he left this world,\nto reach what shines with its own light,\nin the darkness of the night.''");


            dialogueManager.StartDialogue(dialogueManager.dialogue);
            dialogueManager.DisplayNextSentence();

        }

    }
}
