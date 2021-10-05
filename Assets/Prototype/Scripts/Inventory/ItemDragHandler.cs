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
                NPCInteractor.selection.GetChild(1).gameObject.SetActive(true);
                forcinaUI.SetActive(true);
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Sì sì! questo è perfetto! Da sballo! mi dona vero ? Esalta i miei fantastici zigomi!Grazie!");
                    dialogueManager.dialogue.sentences.Add("Ora puoi tenerti la forcina, tutto sommato non era così divertente.");

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
                dialogueManager.dialogue.sentences.Add("Come dovrei mettermel- ehm, come dovrebbe fare la mia ragazza a mettersi questo?");

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

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Uno scolapasta?");
                    dialogueManager.dialogue.sentences.Add("Sì, è perfetto come corona.");
                    dialogueManager.dialogue.sentences.Add("Lo odio");
                    dialogueManager.dialogue.sentences.Add("Dai, non fare i capricci.Nel 1500 abitava un re potentissimo, che indossava proprio questa corona, aveva un sacco di sudditi e persino un'aquila GIGANTE come animale domestico");
                    dialogueManager.dialogue.sentences.Add("WOW, doveva essere un vero figo, sai cosa? Mi piace la corona, ma voglio anche io l’aquila!");
                    dialogueManager.dialogue.sentences.Add("Ma che… ?! ");
                    dialogueManager.dialogue.sentences.Add("Con gli artigli!");
                    dialogueManager.dialogue.sentences.Add("Uff");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }

            }
            else if (NPCInteractor.selection.name == "Bambino" && this.gameObject.name != "ScolapastaUI")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("No! Non voglio questo! Non me ne faccio nulla! Mi serve qualcosa che mi faccia sembrare un re!");

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

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("WOW… che cos'è?");
                    dialogueManager.dialogue.sentences.Add("Questo, mio stupido bambino, è un uovo di pterodattilo.");
                    dialogueManager.dialogue.sentences.Add("DAVVERO? lo voglio! LO VOGLIO! Ma ce li avrà gli artigli?");
                    dialogueManager.dialogue.sentences.Add("… Sì");
                    dialogueManager.dialogue.sentences.Add("Dai dammelo, ecco, te lo scambio per questo biglietto dell'autobus, io non me ne faccio nulla, non mi piace viaggiare.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
                bigliettoUI.SetActive(true);
            }
            else if (NPCInteractor.selection.name == "Bambino" && this.gameObject.name != "UovoUI")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("Nooooo! Questo non c'entra nulla con uccelli GIGANTI!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }

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
            else if (NPCInteractor.selection.name == "Armadio" && this.gameObject.name != "ForcinaUI" && NPCInteractor.armadioScript.playerInRange == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Come dovrei aprirlo con questo?");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }

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
            else if (NPCInteractor.selection.name == "Montacarichi" && this.gameObject.name != "GambaUI")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Nope, non va bene");

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

                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.sentences.Add("oh… OH… OHHHH. Sì questo, lo sento, l’hai preso su una spiaggia vero? Grazie, grazie mille, se chiudo gli occhi posso quasi immaginarlo ");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
                NPCInteractor.uomo.portale.SetActive(true);
            }
            else if (NPCInteractor.selection.name == "Uomo" && this.gameObject.name != "ConchigliaUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.conchigliaPortata = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.sentences.Add("Mmmm, ma conosco questo oggetto e non c'entra nulla con il mare");

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
