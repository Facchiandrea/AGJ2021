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
                Debug.Log("Casco consegnato!");
                forcinaUI.SetActive(true);


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
                Debug.Log("Scolapasta consegnato!");

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
                Debug.Log("Uovo consegnato!");
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
            }

            else if (NPCInteractor.selection.name == "Mongolfiera" && this.gameObject.name == "FiammiferiUI" && NPCInteractor.mongolfieraScript.playerInRange == false && NPCInteractor.mongolfieraScript.traveling == false)
            {
                Debug.Log("Devo avvicinarmi per poter salire");
            }

            else
            {
                transform.GetComponent<RectTransform>().anchoredPosition = startPos;
            }

            //---------------ARMADIO--------------------
            if (NPCInteractor.selection.name == "Armadio" && this.gameObject.name == "ForcinaUI" && NPCInteractor.armadioScript.playerInRange == true)
            {
                Debug.Log("Apriti sesamo!");
                NPCInteractor.armadioAperto = true;
                forcinaUI.SetActive(false);
                NPCInteractor.selection.GetChild(1).gameObject.SetActive(false);

            }
            else if (NPCInteractor.selection.name == "Armadio" && this.gameObject.name == "ForcinaUI" && NPCInteractor.armadioScript.playerInRange == false)
            {
                Debug.Log("Devo avvicinarmi e scassinare quel lucchetto");
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
                Debug.Log("Montacarichi riparato!");
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
                Debug.Log("conchiglia consegnata!");
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
