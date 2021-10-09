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

                    dialogueManager.dialogue.sentences.Add("Yes, yes! This is perfect! Rocking! Suits me, right ? It enhances my awesome cheekbones.Thanks!");
                    dialogueManager.dialogue.sentences.Add("Now you can keep the hairpin. All in all, it wasn't that cool...");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Prendere_oggetto_sfx");
                    }

                }


            }
            else if (NPCInteractor.selection.name == "RagazzoCheVuoleIlCasco" && this.gameObject.name != "CascoUI")
            {
                dialogueManager.dialogue.sentences.Clear();
                dialogueManager.sentences.Clear();
                dialogueManager.dialogue.names.Clear();
                dialogueManager.names.Clear();

                dialogueManager.dialogue.names.Add("Ragazzo");
                dialogueManager.dialogue.sentences.Add("How am I supposed to wear it - er, how is my girlfriend supposed to wear this? Nah, not good as a hat.");

                dialogueManager.StartDialogue(dialogueManager.dialogue);
                dialogueManager.DisplayNextSentence();

                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }
            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------SCOLAPASTA--------------------

            if (NPCInteractor.selection.name == "Prince" && this.gameObject.name == "ScolapastaUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.scolapastaPortato = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Prince");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Prince");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Prince");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("King");
                    dialogueManager.dialogue.names.Add("King");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("King");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("King");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("A colander?");
                    dialogueManager.dialogue.sentences.Add("Yes, it is perfect as a crown.");
                    dialogueManager.dialogue.sentences.Add("I hate it.");
                    dialogueManager.dialogue.sentences.Add("Don't throw a tantrum. In the 1500s, there was a very powerful king who wore exactly this crown.");
                    dialogueManager.dialogue.sentences.Add("Okay, but did he have sunglasses and a mustache?");
                    dialogueManager.dialogue.sentences.Add("...yes.");
                    dialogueManager.dialogue.sentences.Add("Oh. He had to be really cool! Ok, I accept the crown and to celebrate I will make a giant cake!I have sugar, milk, flour, butter, and lots of CHOCOLATE!");
                    dialogueManager.dialogue.sentences.Add("Mmm, I don't know, it just seems like something is missing.");
                    dialogueManager.dialogue.sentences.Add("A person to share this cake with? Like me ;-)");
                    dialogueManager.dialogue.sentences.Add("Nonsense! I'm sure an ingredient is missing, but I don't remember what. Would you help me to find it? AND THEN BRING IT TO ME!");
                    dialogueManager.dialogue.sentences.Add("You already owe me. Why should I?");
                    dialogueManager.dialogue.sentences.Add("Beeecause otherwise I'll start crying aaaand you would hear me in all the paintings!");
                    dialogueManager.dialogue.sentences.Add("Oh god no! Ok you convinced me, stay there.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }

            }
            else if (NPCInteractor.selection.name == "Prince" && this.gameObject.name != "ScolapastaUI" && NPCInteractor.scolapastaPortato == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Prince");

                    dialogueManager.dialogue.sentences.Add("No! I do not want this! That's no good! I need something that makes me look like a king!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }

            }

            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------UOVO--------------------

            if (NPCInteractor.selection.name == "Prince" && this.gameObject.name == "UovoUI")
            {
                this.gameObject.SetActive(false);
                NPCInteractor.uovoPortato = true;
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("King");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("King");

                    dialogueManager.dialogue.sentences.Add("Ah yes, now I remember! I miss the egg!");
                    dialogueManager.dialogue.sentences.Add("Yes, of course, you remember. I just brought it to you.");
                    dialogueManager.dialogue.sentences.Add("Hurray! Now I can make a cake! Give me that! Here, take this bus ticket. I don't need it. I don't like traveling.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Prendere_oggetto_sfx");
                    }

                }
                bigliettoUI.SetActive(true);
            }
            else if (NPCInteractor.selection.name == "Prince" && this.gameObject.name != "UovoUI" && NPCInteractor.scolapastaPortato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("King");

                    dialogueManager.dialogue.sentences.Add("And how am I supposed to make a cake with this?");

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
                if (AudioManager.instance != null)
                {
                    AudioManager.instance.Play("Prendere_autobus_sfx");
                }

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

                    dialogueManager.dialogue.sentences.Add("To infinity and beyond.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Fuoco_mongolfiera_sfx");
                    }
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

                    dialogueManager.dialogue.sentences.Add("I have to get close to get on board.");

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

                    dialogueManager.dialogue.sentences.Add("How am I supposed to light the burner with this?");

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
                    dialogueManager.dialogue.sentences.Add("Open Sesame.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Aprire_armadio_sfx");
                    }

                }
                NPCInteractor.armadioAperto = true;
                forcinaUI.SetActive(false);
                NPCInteractor.selection.GetChild(1).gameObject.SetActive(false);
                NPCInteractor.selection.GetChild(2).gameObject.SetActive(true);

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
                    dialogueManager.dialogue.sentences.Add("How am I supposed to open it with this?");

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
                    dialogueManager.dialogue.sentences.Add("I need to get closer to pick that lock.");

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
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Gamba_Leva_sfx");
                    }

                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Fits like a glove!");

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
                    dialogueManager.dialogue.sentences.Add("Nope, that won't work.");

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

            if (NPCInteractor.selection.name == "Old Man" && this.gameObject.name == "ConchigliaUI" && NPCInteractor.uomo.playerInRange == true)
            {
                this.gameObject.SetActive(false);
                NPCInteractor.conchigliaPortata = true;
                NPCInteractor.compariPortale = true;

                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Oh, finally! Now I can hear the magnificent sound of the waves...");
                    dialogueManager.dialogue.sentences.Add("And besides the sound of the sea, I hear something else... it is like a word that echoes.");
                    dialogueManager.dialogue.sentences.Add("It seems to be like... hocus pocus?");
                    dialogueManager.dialogue.sentences.Add("What the fuck??");
                    dialogueManager.dialogue.sentences.Add("And I hear more, it seems to be a nursery rhyme...");
                    dialogueManager.dialogue.sentences.Add("''In a distant time long ago,\na brave man tried to soar from a château.''");
                    dialogueManager.dialogue.sentences.Add("''He traveled far and wide in all the nations,\nseeing beautiful landscapes and ancient civilizations.''");
                    dialogueManager.dialogue.sentences.Add("''And in the end he left this world,\nto reach what shines with its own light,\nin the darkness of the night.''");
                    dialogueManager.dialogue.sentences.Add("Here, I wrote it to you on a piece of paper if you want a reminder while you're on the go.");
                    dialogueManager.dialogue.sentences.Add("Uhh...thanks i guess.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                    if (AudioManager.instance != null)
                    {
                        AudioManager.instance.Play("Prendere_oggetto_sfx");
                    }

                }
                NPCInteractor.filastroccaUI.SetActive(true);
            }
            else if (NPCInteractor.selection.name == "Old Man" && this.gameObject.name == "ConchigliaUI" && NPCInteractor.uomo.playerInRange == false || NPCInteractor.selection.name == "Old Man" && this.gameObject.name != "ConchigliaUI" && NPCInteractor.uomo.playerInRange == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Better get closer first");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
            }

            else if (NPCInteractor.selection.name == "Old Man" && this.gameObject.name != "ConchigliaUI" && NPCInteractor.uomo.playerInRange == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Old Man");
                    dialogueManager.dialogue.sentences.Add("Mmm, I know this object, and it has nothing to do with the sea.");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                    dialogueManager.DisplayNextSentence();
                }
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
