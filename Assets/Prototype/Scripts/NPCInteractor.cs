using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractor : MonoBehaviour
{
    public FadeInOut fadeInOut;
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;

    public bool tutorialFinito;


    public PickUpCasco pickUpCascoScript;
    public bool cascoPortato = false;

    public PickUpScolapasta pickUpScolapastaScript;
    public PickUpUovo pickUpUovoScript;
    public bool scolapastaPortato = false;
    public bool uovoPortato = false;

    public GameObject bigliettoUI;
    public GameObject player;
    public Transform posizioneStazione1;
    public Transform posizioneStazione2;
    public bool stazione1 = true;

    public PickUpFiammiferi pickUpFiammiferi;
    public bool fiammiferiInInventario = false;

    public Mongolfiera mongolfieraScript;

    public Armadio armadioScript;
    public bool armadioAperto;
    public bool gambaPresa;
    public PickUpGamba pickUpGamba;
    public GameObject gambaLeva;

    public Uomo uomo;
    public Montacarichi montacarichi;
    public bool conchigliaPortata;
    public PickUpConchiglia pickUpConchiglia;

    public DialogueManager dialogueManager;

    private void FixedUpdate()
    {
        if (_selectionItem != null)
        {
            selection.GetChild(0).gameObject.SetActive(false);
            _selectionItem = null;
            selection = null;
        }

        if (viewModeSwap.fullView == false && viewModeSwap.transitionToSingle == false)
        {
            int layerMask = LayerMask.GetMask("NPCs");
            Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero, 1000f, layerMask);

            if (cubeHit && cubeHit.transform.CompareTag("NPC"))
            {
                selection = cubeHit.transform;
                selection.GetChild(0).gameObject.SetActive(true);
                _selectionItem = selection;
            }

        }
    }

    private void Update()
    {
        if (selection != null && fadeInOut.fadeTransition == false)
        {
            //-----------------TUTORIAL----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == false)
            {
                tutorialFinito = true;

                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("???");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Tut Orial");

                    dialogueManager.dialogue.sentences.Add("Ciao, il mio nome è Tut, ma puoi chiamarmi Orial");
                    dialogueManager.dialogue.sentences.Add("...Seriamente?");
                    dialogueManager.dialogue.sentences.Add("Tutorial testo");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Tut Orial");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Tut Orial");

                    dialogueManager.dialogue.sentences.Add("Sei ancora qua?");
                    dialogueManager.dialogue.sentences.Add("Si");
                    dialogueManager.dialogue.sentences.Add("Ciao");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            //-----------------RAGAZZO----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Voglio un cappello");
                    dialogueManager.dialogue.sentences.Add("Ok");
                    dialogueManager.dialogue.sentences.Add("Qualcosa di unico però");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpCascoScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Ragazzo");

                    dialogueManager.dialogue.sentences.Add("Non vedo niente");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //-----------------BAMBINO----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("Voglio un copricapo degno di un re");
                    dialogueManager.dialogue.sentences.Add("Ok");
                    dialogueManager.dialogue.sentences.Add("SONO IL RE, AONNA CARA POPO FIERO CON LA CARTA GIALLA DELLO ZIO PEPPE");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpScolapastaScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == true && uovoPortato == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Bambino");

                    dialogueManager.dialogue.sentences.Add("Ora voglio un'aquila gigante o qualcosa che vola con gli artigli");
                    dialogueManager.dialogue.sentences.Add("Ok");
                    dialogueManager.dialogue.sentences.Add("VOGLIO UNO PTERODATTILO");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpUovoScript.canPickUp = true;

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && uovoPortato == true && uovoPortato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Bambino");
                    dialogueManager.dialogue.sentences.Add("GRAZIE PER TUTTO ORA SONO FELICIO");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //-----------------AUTOBUS----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == true)
            {
                ViaggioInAutobus();
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Non ho il biglietto per usarlo");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //-----------------Mongolfiera----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == false && mongolfieraScript.traveling == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Mi serve qualcosa per attivare il bruciatore");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }

                pickUpFiammiferi.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == false && mongolfieraScript.traveling == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Devo avvicinarmi per poter salire!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == true && mongolfieraScript.traveling == false)
            {
                mongolfieraScript.ViaggioInMongolfiera();
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");

                    dialogueManager.dialogue.sentences.Add("Si parte!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);
                }

            }

            //-----------------Armadio----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("E' un armadio con un lucchetto");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && armadioScript.playerInRange == true && gambaPresa == false && pickUpGamba.canPickUp == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Questa gamba di legno fa al caso mio");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpGamba.PickUpUIGraphics.SetActive(true);
                pickUpGamba.PickUpGraphics.SetActive(false);
                gambaPresa = true;

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && gambaPresa == true || Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && gambaPresa == false && pickUpGamba.canPickUp == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("E' una bella collezione di gambe di legno");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            //------------------MONTACARICHI-------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.montacarichiRiparato == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("La leva è rotta, devo sostituirla con qualcosa");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpGamba.canPickUp = true;
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.playerInRange == true && montacarichi.montacarichiRiparato == true && montacarichi.traveling == false)
            {
                montacarichi.SpostamentoInMontacarichi();
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.playerInRange == false && montacarichi.montacarichiRiparato == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Devo salire sul montacarichi, prima");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            //------------------UOMO-------------------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Uomo");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Uomo");

                    dialogueManager.dialogue.sentences.Add("Voglio una conchiglia");
                    dialogueManager.dialogue.sentences.Add("Ok");
                    dialogueManager.dialogue.sentences.Add("Ciao");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
                pickUpConchiglia.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == false)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("Credo che quel tipo sia sordo, dovrei prima avvicinarmi");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && conchigliaPortata == true)
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.sentences.Add("E' ora di svegliarsi!");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            //------------------PECORE-------------------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 3")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Rebeeecca");
                    dialogueManager.dialogue.names.Add("Artemisia");
                    dialogueManager.dialogue.names.Add("Rebeeecca");

                    dialogueManager.dialogue.sentences.Add("Dio non esiste e noi siamo solo degli inutili involucri pluricellulari");
                    dialogueManager.dialogue.sentences.Add("...what?!");
                    dialogueManager.dialogue.sentences.Add("ehm...Beeeee!");


                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 1")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Beeeatrice");

                    dialogueManager.dialogue.sentences.Add("Baaaaaa");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }
            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 2")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Baaarbara");

                    dialogueManager.dialogue.sentences.Add("Beeee");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }

            if (Input.GetMouseButtonDown(0) && selection.name == "Pecora 4")
            {
                if (dialogueManager.inDialogue == false)
                {
                    dialogueManager.dialogue.sentences.Clear();
                    dialogueManager.sentences.Clear();
                    dialogueManager.dialogue.names.Clear();
                    dialogueManager.names.Clear();

                    dialogueManager.dialogue.names.Add("Beeeth");

                    dialogueManager.dialogue.sentences.Add("Baaaaaa");

                    dialogueManager.StartDialogue(dialogueManager.dialogue);

                }
            }



        }
    }

    public void ViaggioInAutobus()
    {
        if (stazione1 == true)
        {
            bigliettoUI.SetActive(false);
            Invoke("PlayerTP", 1f);
            fadeInOut.FadeIn();
            Debug.Log("VadoAStazione2");

        }
        else if (stazione1 == false)
        {
            bigliettoUI.SetActive(false);
            Invoke("PlayerTP", 1f);
            fadeInOut.FadeIn();
            Debug.Log("VadoAStazione1");
        }

    }

    public void PlayerTP()
    {
        if (stazione1 == true)
        {
            stazione1 = false;
            player.transform.position = posizioneStazione2.position;
        }
        else if (stazione1 == false)
        {
            stazione1 = true;
            player.transform.position = posizioneStazione1.position;
        }

    }
}
