using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scala : MonoBehaviour
{
    public ScalaChecker scalaChecker;
    public DialogueManager dialogueManager;
    public Transform pos1;
    public Transform pos2;
    public GameObject player;
    public FadeInOut fadeInOut;

    public bool playerAllaScogliera = true;

    public void Spostamento()
    {
        if (scalaChecker.scalaTrovata && fadeInOut.fadeTransition == false)
        {
            if (AudioManager.instance != null)
            {
                AudioManager.instance.Play("Scale_sfx");
            }
            fadeInOut.FadeIn();
            Invoke("Teleporting", 1f);
        }
        else if (scalaChecker.scalaTrovata == false)
        {
            if (dialogueManager.inDialogue == false)
            {
                dialogueManager.dialogue.sentences.Clear();
                dialogueManager.sentences.Clear();
                dialogueManager.dialogue.names.Clear();
                dialogueManager.names.Clear();

                dialogueManager.dialogue.names.Add("Artemisia");

                dialogueManager.dialogue.sentences.Add("This ladder leads nowhere.");

                dialogueManager.StartDialogue(dialogueManager.dialogue);

            }

        }
    }

    public void Teleporting()
    {
        if (playerAllaScogliera)
        {
            player.transform.position = pos2.position;
            playerAllaScogliera = false;
        }
        else if (playerAllaScogliera == false)
        {
            player.transform.position = pos1.position;
            playerAllaScogliera = true;
        }

    }
}
