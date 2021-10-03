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
                Debug.Log("Tutorial");
                tutorialFinito = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Tutorial" && tutorialFinito == true)
            {
                Debug.Log("Tutorial 2");
            }

            //-----------------RAGAZZO----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == false)
            {
                Debug.Log("Mi serve un casco");
                pickUpCascoScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && cascoPortato == true)
            {
                Debug.Log("Grazie per il casco!");
            }
            //-----------------BAMBINO----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == false)
            {
                Debug.Log("Mi serve uno scolapasta");
                pickUpScolapastaScript.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && scolapastaPortato == true && uovoPortato == false)
            {
                Debug.Log("Ora voglio un uovo");
                pickUpUovoScript.canPickUp = true;

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Bambino" && uovoPortato == true && uovoPortato == true)
            {
                Debug.Log("Grazie per tutto!");
            }
            //-----------------AUTOBUS----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == true)
            {
                ViaggioInAutobus();
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Autobus" && bigliettoUI.activeInHierarchy == false)
            {
                Debug.Log("Non ho il biglietto per utilizzarlo");
            }
            //-----------------Mongolfiera----------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == false && mongolfieraScript.traveling == false)
            {
                Debug.Log("Mi serve qualcosa per attivare il bruciatore");
                pickUpFiammiferi.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == false && mongolfieraScript.traveling == false)
            {
                Debug.Log("Devo avvicinarmi per poter salire");
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == true && mongolfieraScript.traveling == false)
            {
                mongolfieraScript.ViaggioInMongolfiera();
            }

            //-----------------Armadio----------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == false)
            {
                Debug.Log("E' un armadio con un lucchetto");
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && armadioScript.playerInRange == true && gambaPresa == false && pickUpGamba.canPickUp == true)
            {
                Debug.Log("Questa gamba di legno fa al caso mio");
                pickUpGamba.PickUpUIGraphics.SetActive(true);
                pickUpGamba.PickUpGraphics.SetActive(false);
                gambaPresa = true;

            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Armadio" && gambaPresa == true || Input.GetMouseButtonDown(0) && selection.name == "Armadio" && armadioAperto == true && gambaPresa == false && pickUpGamba.canPickUp == false)
            {
                Debug.Log("E'una bella collezione di gambe di legno");
            }
            //------------------MONTACARICHI-------------
            if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.montacarichiRiparato == false)
            {
                Debug.Log("La leva è rotta, devo sostituirla con qualcosa");
                pickUpGamba.canPickUp = true;
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.playerInRange == true && montacarichi.montacarichiRiparato == true && montacarichi.traveling == false)
            {
                montacarichi.SpostamentoInMontacarichi();
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Montacarichi" && montacarichi.playerInRange == false && montacarichi.montacarichiRiparato == true)
            {
                Debug.Log("Devo salire sul montacarichi prima");
            }

            //------------------UOMO-------------------------

            if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == true)
            {
                Debug.Log("Mi serve una conchiglia");
                pickUpConchiglia.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Uomo" && conchigliaPortata == false && uomo.playerInRange == false)
            {
                Debug.Log("Eiiiiii!...credo che il vecchio sia mezzo sordo, dovrei avvicinarmi a lui per parlarci");
            }

            else if (Input.GetMouseButtonDown(0) && selection.name == "RagazzoCheVuoleIlCasco" && conchigliaPortata == true)
            {
                Debug.Log("E' ora di andare!");
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
