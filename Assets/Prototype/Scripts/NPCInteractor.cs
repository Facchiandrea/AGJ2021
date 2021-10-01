using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractor : MonoBehaviour
{
    public FadeInOut fadeInOut;
    public ViewModeSwap viewModeSwap;
    private Transform _selectionItem;
    public Transform selection;

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
            if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == false)
            {
                Debug.Log("Mi serve qualcosa per attivare il bruciatore");
                pickUpFiammiferi.canPickUp = true;
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == false)
            {
                Debug.Log("Devo avvicinarmi per poter salire");
            }
            else if (Input.GetMouseButtonDown(0) && selection.name == "Mongolfiera" && fiammiferiInInventario == true && mongolfieraScript.playerInRange == true)
            {
                Debug.Log("Wiiiiii");
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
