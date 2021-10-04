using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public NPCInteractor NPCInteractor;
    Vector2 startPos;
    public GameObject bigliettoUI;
    public GameObject forcinaUI;
    public FadeInOut fadeInOut;
    public DialogueManager dialogueManager;

    private void Start()
    {
        startPos = this.gameObject.GetComponent<RectTransform>().anchoredPosition;
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        CheckInterations();

    }

    public void CheckInterations()
    {
        if (NPCInteractor.selection != null && fadeInOut.fadeTransition == false)
        {
            //---------------CASCO--------------------
            if (NPCInteractor.selection.name == "RagazzoCheVuoleIlCasco" && this.gameObject.name == "CascoUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.cascoPortato = true;
                forcinaUI.SetActive(true);
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Ecco il casco!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }


            }
            else if (NPCInteractor.selection.name == "RagazzoCheVuoleIlCasco" && this.gameObject.name != "CascoUI")
            {
                dialogueManager.dialogue.sentences.Clear();
                dialogueManager.sentences.Clear();
                dialogueManager.dialogue.names.Clear();
                dialogueManager.names.Clear();

                dialogueManager.dialogue.names.Add("Ragazzo");
                dialogueManager.dialogue.sentences.Add("Non questo!");

                dialogueManager.StartDialogue(dialogueManager.dialogue);
                dialogueManager.DisplayNextSentence();

                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------SCOLAPASTA--------------------

            if (NPCInteractor.selection.name == "Bambino" && this.gameObject.name == "ScolapastaUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.scolapastaPortato = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Ecco lo scolapasta!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }

            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------UOVO--------------------

            if (NPCInteractor.selection.name == "Bambino" && this.gameObject.name == "UovoUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.uovoPortato = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Ecco un uovo, è di pterodattilo!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
                bigliettoUI.SetActive(true);
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------AUTOBUS--------------------

            if (NPCInteractor.selection.name == "Autobus" && this.gameObject.name == "BigliettoUI")
            {
                NPCInteractor.ViaggioInAutobus();
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------MONGOLFIERA--------------------
            if (NPCInteractor.selection.name == "Mongolfiera" && this.gameObject.name == "FiammiferiUI" && NPCInteractor.mongolfieraScript.playerInRange == true && NPCInteractor.mongolfieraScript.traveling == false)
            {
                NPCInteractor.mongolfieraScript.ViaggioInMongolfiera();
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Si parte!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();

                }

            }

            else if (NPCInteractor.selection.name == "Mongolfiera" && this.gameObject.name == "FiammiferiUI" && NPCInteractor.mongolfieraScript.playerInRange == false && NPCInteractor.mongolfieraScript.traveling == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Devo avvicinarmi per poter salire");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();

                }

            }

            else if (NPCInteractor.selection.name == "Mongolfiera" && this.gameObject.name != "FiammiferiUI")
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Come dovrei accenderlo con questo?");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();

                }

            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------ARMADIO--------------------
            if (NPCInteractor.selection.name == "Armadio" && this.gameObject.name == "ForcinaUI" && NPCInteractor.armadioScript.playerInRange == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Apriti sesamo!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
                NPCInteractor.armadioAperto = true;
                forcinaUI.SetActive(false);
                NPCInteractor.selection.GetChild(1).gameObject.SetActive(false);

            }
            else if (NPCInteractor.selection.name == "Armadio" && this.gameObject.name == "ForcinaUI" && NPCInteractor.armadioScript.playerInRange == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Devo avvicinarmi e scassinare quel lucchetto");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }
            //----------------MONTACARICHI----------------

            if (NPCInteractor.selection.name == "Montacarichi" && this.gameObject.name == "GambaUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.montacarichi.montacarichiRiparato = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Calza a pennello");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
                NPCInteractor.gambaLeva.SetActive(true);
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //----------------CONCHIGLIA----------------

            if (NPCInteractor.selection.name == "Uomo" && this.gameObject.name == "ConchigliaUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.conchigliaPortata = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Ecco la tua conchiglia!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
                NPCInteractor.uomo.portale.SetActive(true);
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

        }
        else
        {
            transform.GetComponent<RectTransform>().anchoredPosition = startPos;
        }

    }
}
